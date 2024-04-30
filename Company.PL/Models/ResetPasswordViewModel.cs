using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.PL.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        [Compare(nameof(Password), ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
