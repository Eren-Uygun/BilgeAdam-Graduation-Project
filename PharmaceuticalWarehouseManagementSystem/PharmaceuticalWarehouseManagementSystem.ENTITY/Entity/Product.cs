using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
    public class Product:KernelEntity
    {
        public Product()
        {

        }

       [Required(ErrorMessage = "Please Enter Product Name")]
        public string ProductName { get; set; }
        

        public Guid? SupplierID { get; set; }

        public Guid? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        [Required(ErrorMessage = "Please Select Reorder Level")]
        public ReorderLevel ReorderLevel { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; } 
        public virtual Supplier Supplier { get; set; }

        public  virtual  ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
