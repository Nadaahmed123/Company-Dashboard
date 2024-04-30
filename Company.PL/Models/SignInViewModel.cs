using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.PL.Models
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Format for email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(8)]
        public string Password { get; set; }

      
        public bool RememberMe{ get; set; }
    }
}
