using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Company.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department name is Required ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department Code is Required ")]
        public string Code { get; set; }
        public DateTime CreateAt { set; get; } = DateTime.Now;

    }
}
