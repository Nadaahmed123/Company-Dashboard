using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.PL.Models
{
    public class DepartmentViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Department name is Required ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department Code is Required ")]
        public string Code { get; set; }
        public DateTime CreateAt { set; get; } = DateTime.Now;
    }
}
