using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Company.PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Please select active status")]
        public bool IsActive { get; set; }

        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; } = DateTime.Now;

        public IFormFile Image { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}