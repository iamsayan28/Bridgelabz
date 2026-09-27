using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Data
{
    /// <summary>
    /// Handles all database access for Employees using plain ADO.NET
    /// (MySqlConnection, MySqlCommand, MySqlDataReader, MySqlParameter).
    /// Entity Framework is intentionally not used.
    /// </summary>
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand("SELECT * FROM Employees ORDER BY EmployeeId", connection))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(MapEmployee(reader));
                    }
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand("SELECT * FROM Employees WHERE EmployeeId = @EmployeeId", connection))
            {
                command.Parameters.Add(new MySqlParameter("@EmployeeId", employeeId));
                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapEmployee(reader);
                    }
                }
            }

            return null;
        }

        public void AddEmployee(Employee employee)
        {
            const string sql = @"INSERT INTO Employees
                (EmployeeCode, FirstName, LastName, Email, PhoneNumber, Department, Designation, Salary, DateOfJoining)
                VALUES
                (@EmployeeCode, @FirstName, @LastName, @Email, @PhoneNumber, @Department, @Designation, @Salary, @DateOfJoining)";

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(sql, connection))
            {
                AddEmployeeParameters(command, employee);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            const string sql = @"UPDATE Employees SET
                EmployeeCode = @EmployeeCode,
                FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email,
                PhoneNumber = @PhoneNumber,
                Department = @Department,
                Designation = @Designation,
                Salary = @Salary,
                DateOfJoining = @DateOfJoining
                WHERE EmployeeId = @EmployeeId";

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(sql, connection))
            {
                AddEmployeeParameters(command, employee);
                command.Parameters.Add(new MySqlParameter("@EmployeeId", employee.EmployeeId));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand("DELETE FROM Employees WHERE EmployeeId = @EmployeeId", connection))
            {
                command.Parameters.Add(new MySqlParameter("@EmployeeId", employeeId));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void AddEmployeeParameters(MySqlCommand command, Employee employee)
        {
            command.Parameters.Add(new MySqlParameter("@EmployeeCode", employee.EmployeeCode));
            command.Parameters.Add(new MySqlParameter("@FirstName", employee.FirstName));
            command.Parameters.Add(new MySqlParameter("@LastName", employee.LastName));
            command.Parameters.Add(new MySqlParameter("@Email", employee.Email));
            command.Parameters.Add(new MySqlParameter("@PhoneNumber", employee.PhoneNumber));
            command.Parameters.Add(new MySqlParameter("@Department", employee.Department));
            command.Parameters.Add(new MySqlParameter("@Designation", (object)employee.Designation ?? DBNull.Value));
            command.Parameters.Add(new MySqlParameter("@Salary", employee.Salary));
            command.Parameters.Add(new MySqlParameter("@DateOfJoining", employee.DateOfJoining));
        }

        private static Employee MapEmployee(MySqlDataReader reader)
        {
            return new Employee
            {
                EmployeeId = (int)reader["EmployeeId"],
                EmployeeCode = reader["EmployeeCode"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Department = reader["Department"].ToString(),
                Designation = reader["Designation"] == DBNull.Value ? string.Empty : reader["Designation"].ToString(),
                Salary = (decimal)reader["Salary"],
                DateOfJoining = (DateTime)reader["DateOfJoining"]
            };
        }
    }
}
