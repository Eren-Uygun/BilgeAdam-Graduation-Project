using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
   
   public class OrderDetail:KernelEntity
    {

        [Required(ErrorMessage = "Please Select OrderID")]
        public Guid OrderID { get; set; }
        [Required(ErrorMessage = "Please Select Product")]
        public Guid ProductID { get; set; }
        [Required(ErrorMessage = "Please Select Shipper")]
        public Guid ShipperID { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; } 
        public virtual Shipper Shipper { get; set; }
    

    }
}
