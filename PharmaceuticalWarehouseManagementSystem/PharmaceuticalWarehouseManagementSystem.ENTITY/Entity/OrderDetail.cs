using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
   
   public class OrderDetail:KernelEntity
    {

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int ShipperID { get; set; }
 
        public decimal UnitPrice { get; set; }
 
        public int Quantity { get; set; }
        
        public decimal Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; } 
        public virtual Shipper Shipper { get; set; }
    

    }
}
