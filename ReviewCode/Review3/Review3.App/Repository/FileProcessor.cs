using System;
using System.Collections.Generic;
using System.IO;

public class FileProcessor
{
	private readonly IRepository _repository;
	private readonly EmployeeValidator _validator;

	public FileProcessor(IRepository repository, EmployeeValidator validator)
	{
		_repository = repository;
		_validator = validator;
	}

	public List<AuditRecord> ProcessFile(string inputFilePath, string errorLogPath)
	{
		var auditRecords = new List<AuditRecord>();

		if (!File.Exists(inputFilePath))
			throw new FileNotFoundException($"Input file not found: {inputFilePath}");

		using (var reader = new StreamReader(inputFilePath))
		using (var errorWriter = new StreamWriter(errorLogPath, append: true))
		{
			reader.ReadLine(); // Skip header

			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (string.IsNullOrWhiteSpace(line)) continue;

				var parts = line.Split(',');

				// 1. Parsing
				Employee emp;
				try
				{
					emp = new Employee(
						int.Parse(parts[0].Trim()),
						parts[1].Trim(),
						parts[2].Trim(),
						parts[3].Trim(),
						parts[4].Trim(),
						double.Parse(parts[5].Trim()),
						DateTime.Parse(parts[6].Trim()),
						parts[7].Trim(),
						parts[8].Trim()
					);
				}
				catch (Exception ex)
				{
					errorWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Parse Error: {ex.Message} | Line: {line}");
					continue;
				}

				// 2. Validation
				if (!_validator.Validate(emp, out List<string> errors))
				{
					string reason = string.Join("; ", errors);
					errorWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {reason} | Line: {line}");

					auditRecords.Add(new AuditRecord
					{
						EmployeeId = emp.EmployeeId,
						EmployeeName = emp.Name,
						ProcessingStatus = ProcessingStatus.INVALID,
						ValidationStatus = "FAILED",
						DatabaseStatus = "SKIPPED",
						Reason = reason
					});
					continue;
				}

				// 3. Duplicate Check
				if (_repository.Exists(emp.EmployeeId))
				{
					errorWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Duplicate ID | Line: {line}");

					auditRecords.Add(new AuditRecord
					{
						EmployeeId = emp.EmployeeId,
						EmployeeName = emp.Name,
						ProcessingStatus = ProcessingStatus.DUPLICATE,
						ValidationStatus = "PASSED",
						DatabaseStatus = "SKIPPED",
						Reason = "Employee ID already exists"
					});
					continue;
				}

				// 4. Database Insert
				try
				{
					_repository.AddEmployee(emp);
					auditRecords.Add(new AuditRecord
					{
						EmployeeId = emp.EmployeeId,
						EmployeeName = emp.Name,
						ProcessingStatus = ProcessingStatus.SUCCESS,
						ValidationStatus = "PASSED",
						DatabaseStatus = "INSERTED",
						Reason = "Processed Successfully"
					});
				}
				catch (Exception dbEx)
				{
					errorWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | DB Error: {dbEx.Message} | Line: {line}");

					auditRecords.Add(new AuditRecord
					{
						EmployeeId = emp.EmployeeId,
						EmployeeName = emp.Name,
						ProcessingStatus = ProcessingStatus.DATABASE_FAILURE,
						ValidationStatus = "PASSED",
						DatabaseStatus = "FAILED",
						Reason = dbEx.Message
					});
				}
			}
		}

		return auditRecords;
	}
}