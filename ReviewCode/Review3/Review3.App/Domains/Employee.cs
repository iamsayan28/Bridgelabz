using System.ComponentModel.DataAnnotations;
public class Employee
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Employee ID must be greater than 0.")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Name cannot be empty.")]
    public string Name { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required]
    [AllowedValues("IT", "HR", "Finance", "Sales", ErrorMessage = "Department not accepted.")]
    public string Department { get; set; }

    [Required]
    public string Designation { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
    public double Salary { get; set; }

    [NotFutureDate(ErrorMessage = "Joining date cannot be in the future.")]
    public DateTime JoiningDate { get; set; }

    [Required]
    [AllowedValues("FullTime", "PartTime", "Contract", ErrorMessage = "Invalid employment type.")]
    public string EmploymentType { get; set; }

    [Required]
    [AllowedValues("Active", "Inactive", "OnLeave", ErrorMessage = "Invalid status.")]
    public string Status { get; set; }

    public Employee(int id, string name, string email, string dept, string desig, double salary, DateTime joiningDate, string empType, string status)
    {
        EmployeeId = id;
        Name = name;
        Email = email;
        Department = dept;
        Designation = desig;
        Salary = salary;
        JoiningDate = joiningDate;
        EmploymentType = empType;
        Status = status;
    }
}