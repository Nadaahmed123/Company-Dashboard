using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        public int Age { set; get; }
        public string Address { set; get; }
        [EmailAddress]
        public string Email { set; get; }
        [Column(TypeName = "money")]
        public double Salary { set; get; }
        public bool isActive { set; get; }
        public DateTime HireDate { set; get; } = DateTime.Now;
    public IFormFile Image { set; get; }
        public string ImageUrl { set; get; }
        public int DepartmentId { set; get; }


    }
}
