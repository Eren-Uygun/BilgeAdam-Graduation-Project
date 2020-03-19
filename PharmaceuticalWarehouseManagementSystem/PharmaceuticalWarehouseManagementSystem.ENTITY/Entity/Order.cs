using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
   public class Order:KernelEntity
    {
        public Order()
        {
          
        }


        public Guid? CustomerID { get; set; }

        public Guid? EmployeeID { get; set; }
        public DateTime? ShippedDate { get; set; }

        public DateTime? OrderDate { get; set; }

        public string ShipCity { get; set; }

        public string ShipAddress { get; set; }

        public double? Freight { get; set; }

   
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; } 

        public ICollection<OrderDetail> OrderDetails { get; set; }


     


    }
}
