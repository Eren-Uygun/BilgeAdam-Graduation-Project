using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.KERNEL.Enum
{
    public enum Status
    {
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "Modified")]
        Modified = 2,
        [Display(Name = "Passive")]
        Passive = 3
    }
}
