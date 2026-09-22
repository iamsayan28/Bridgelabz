internal class Program
{
    static void Main(string[] args)
    {
        string conn = "Server=localhost;Port=3306;Database=EmployeeComplianceDB;User ID=root;Password=sayan@2005;";
        IRepository repo = new MySqlRepository(conn);
        var processor = new FileProcessor(repo, new EmployeeValidator());
        var reporter = new AuditReporter();

        while (true)
        {
            Console.Write("\n1.Import 2.FindById 3.FindByDept 4.FindByStatus 5.Delete 6.Exit\nChoice: ");
            switch (Console.ReadLine())
            {
                case "1":
                    var audit = processor.ProcessFile("employees.csv", "rejected_records.txt");
                    reporter.ExportReport(audit, "audit_report.csv");
                    Console.WriteLine("Done.");
                    break;
                case "2":
                    Console.Write("ID: ");
                    var emp = repo.GetEmployeeById(int.Parse(Console.ReadLine()));
                    Console.WriteLine(emp != null ? $"{emp.Name} | {emp.Department}" : "Not found.");
                    break;
                case "3":
                    Console.Write("Dept: ");
                    foreach (var e in repo.SearchByDepartment(Console.ReadLine()))
                        Console.WriteLine($"{e.EmployeeId}: {e.Name}");
                    break;
                case "4":
                    Console.Write("Status: ");
                    foreach (var e in repo.SearchByStatus(Console.ReadLine()))
                        Console.WriteLine($"{e.EmployeeId}: {e.Name}");
                    break;
                case "5":
                    Console.Write("ID to delete: ");
                    repo.DeleteEmployee(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Deleted.");
                    break;
                case "6":
                    return;
            }
        }
    }
}