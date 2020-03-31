using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;

namespace PharmaceuticalWarehouseManagementSystem.UI.Models
{
    public class LoginViewModel:IdentityUser
    {
        [Required(ErrorMessage = "Please enter EmailAdress"),Display(Name = "Username/Email"),EmailAddress,DataType(DataType.EmailAddress)]
        public string UserMail { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        public RoleModel Role { get; set; }

        public  bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
