using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.KERNEL.Enum
{
    public enum Role
    {
        None = 0,
        [Display(Name = "User")]
        User = 1,
        [Display(Name = "Admin")]
        Admin = 2
        
    }
}
