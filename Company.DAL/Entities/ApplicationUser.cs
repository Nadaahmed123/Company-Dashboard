using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Company.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool isActive{get;set;}
    }
}
