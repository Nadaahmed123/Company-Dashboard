using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Company.PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { set; get; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { set; get; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Salary is required")]
        // [Range(0, double.MaxValue, ErrorMessage = "Invalid salary")]
        public double Salary { set; get; }

        [Required(ErrorMessage = "Please select active status")]
        public bool isActive { set; get; }

        [Display(Name = "Hire Date")]
        public DateTime HireDate { set; get; } = DateTime.Now;

     
        public IFormFile Image { set; get; }

        // Property to store the URL of the uploaded image
        public string ImageUrl { set; get; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { set; get; }
        public DepartmentViewModel? Department { get; set; }
    }
}
