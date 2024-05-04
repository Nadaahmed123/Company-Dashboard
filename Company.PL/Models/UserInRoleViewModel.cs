using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.PL.Models
{
    public class UserInRoleViewModel
    {
        public string UserId{get;set;}
        public string UserName{get;set;}
        public bool IsSelected{get;set;}
        

    }
}
