using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;

namespace PharmaceuticalWarehouseManagementSystem.UI.Models
{
    public class RoleModel:IdentityRole<Guid>
    {
        public Role Role { get; set; }
    }
}
