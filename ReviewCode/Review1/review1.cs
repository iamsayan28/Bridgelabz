using System.Collections;
using System.Reflection.Metadata.Ecma335;

abstract class EmployeeContract
{
    public abstract int GetId();
    public abstract string GetName();
    public abstract string GetRole();
    public abstract void SetRole(string role);
    public abstract int GetAttendance();
    public abstract void SetAttendance(int days);
    public abstract int GetOvertimeRecord();
    public abstract void SetOvertimeRecord(int overtimeHrs);

}

// Every Employee object must implement WRT Employee Contract
class Employee : EmployeeContract
{
    private readonly string name;
    private int id;
    private string role;
    private int daysPresent;

    private int overtimeHrs;
    public Employee(string name, int id, string role, int daysPresent, int overtimeHrs)
    {
        this.name = name;
        this.id = id;
        this.role = role;
        this.daysPresent = daysPresent;
        this.overtimeHrs = overtimeHrs;
    }

    public override int GetId()
    {
        return id;
    }
    public override string GetName()
    {
        return name;
    }
    public override string GetRole()
    {
        return role;
    }

    public override void SetRole(string role)
    {
        this.role = role;
    }

    public override int GetAttendance()
    {
        return daysPresent;
    }

    public override void SetAttendance(int daysPresent)
    {
        this.daysPresent = daysPresent;
    }

    public override int GetOvertimeRecord()
    {
        return overtimeHrs;
    }

    public override void SetOvertimeRecord(int overtimeHrs)
    {
        this.overtimeHrs = overtimeHrs;
    }

}

class EmployeeManagement
{
    public static void Main(String[] args)
    {
        HashSet<int> set = new HashSet<int>(); // hashset for duplicate IDs

        int N = int.Parse(Console.ReadLine());

        Employee[] arr = new Employee[N]; // arr for containing each Employee objs
        for (int i = 0; i < N; i++)
        {
            // Employee input from the user
            int id = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            string role = Console.ReadLine();
            int daysPresent = int.Parse(Console.ReadLine());
            int overtimeHrs = int.Parse(Console.ReadLine());

            try
            {
                if (set.Contains(id))
                {
                    throw new Exception("ID Already Present Exception");
                }

                Employee employee = new Employee(name, id, role, daysPresent, overtimeHrs);
                set.Add(id);
                arr[i] = employee;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // Salary Calulation with respect to Employee Role and No. of days he/she has been present
        for (int i = 0; i < N; i++)
        {
            if (arr[i] == null) continue;

            string employeeRole = arr[i].GetRole().ToLower();
            int daysPresent = arr[i].GetAttendance();
            string employeeName = arr[i].GetName();
            int overtimeHrs = arr[i].GetOvertimeRecord();

            if (employeeRole == "sde")
            {
                // salary -> 50$ per hour
                int salary = (50 * 8 * daysPresent) + (50 * overtimeHrs);
                Console.WriteLine($"Salary of Employee -> {employeeName} is {salary}");
            }
            else if (employeeRole == "testing")
            {
                // salary -> 40$ per hour
                int salary = (40 * 8 * daysPresent) + (40 * overtimeHrs);
                Console.WriteLine($"Salary of Employee -> {employeeName} is {salary}");
            }
            else if (employeeRole == "intern")
            {
                // salary -> 30$ per hour
                int salary = (30 * 8 * daysPresent) + (30 * overtimeHrs);
                Console.WriteLine($"Salary of Employee: {employeeName}, Role: {employeeRole} is ${salary}");
            }
        }
    }
}
