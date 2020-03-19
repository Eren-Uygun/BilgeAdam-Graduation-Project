using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
    public class Product:KernelEntity
    {
        public Product()
        {
        }
       
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int? UnitsInOrder { get; set; }

        public int? ReorderLevel { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; } 
        public virtual Supplier Supplier { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public  virtual  ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
