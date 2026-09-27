using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningWebApp1.Models
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage ="Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 to 50 characters")]
        public string FullName { get; protected set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; protected set; }
        [Range(18,100, ErrorMessage = "Must be a valid age number between 18 and 100")]
        public int Age { get; protected set; }
    }
}