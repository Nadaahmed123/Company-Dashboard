using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.PL.Models
{
    public class ForgetPasswordViewModel
    {
        [Required]
         [EmailAddress(ErrorMessage = "Invalid Format for email")]
        public string Email { set; get; }
    }
}