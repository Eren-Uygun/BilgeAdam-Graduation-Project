using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.KERNEL.Enum
{
    public enum Role
    {
        [Display(Name = "Employee")]
        Employeee = 1,
        [Display(Name = "Admin")]
        Admin = 2,
        [Display(Name = "Other")]
        Other = 3
    }
}
