using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Code is required.")]
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Date of Joining is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Joining")]
        public DateTime DateOfJoining { get; set; }
    }
}
