using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PharmaceuticalWarehouseManagementSystem.KERNEL.Entity
{
    public class KernelEntity : IEntity<int>
    {
        public KernelEntity()
        {

        }
        public int ID { get; set; }
        public Status Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedComputerName { get; set; }
        public string RemovedIP { get; set; }
        public string RemovedComputerName { get; set; }
       



    }
}
