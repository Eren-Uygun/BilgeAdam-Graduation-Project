using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
   public class Order:KernelEntity
    {
        public Order()
        {
          
        }
        
        [Required(ErrorMessage = "Please Select Customer")]
        public Guid? CustomerID { get; set; }
        [Required(ErrorMessage ="Please Select Employee")]
        public Guid? EmployeeID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ShippedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public string ShipCity { get; set; }

        public string ShipAddress { get; set; }

        [Range(0,double.MaxValue,ErrorMessage ="Positive values allowed")]
        public double? Freight { get; set; }

   
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; } 

        public ICollection<OrderDetail> OrderDetails { get; set; }


     


    }
}
