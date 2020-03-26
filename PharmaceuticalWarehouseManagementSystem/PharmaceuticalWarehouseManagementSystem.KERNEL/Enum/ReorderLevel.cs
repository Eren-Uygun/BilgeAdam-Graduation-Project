using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.KERNEL.Enum
{
   public enum ReorderLevel
    {
        [Display(Name = "Low")]
        Low = 1,
        [Display(Name = "Medium")]
        Medium =2,
        [Display(Name = "High")]
        High =3
    }
}
