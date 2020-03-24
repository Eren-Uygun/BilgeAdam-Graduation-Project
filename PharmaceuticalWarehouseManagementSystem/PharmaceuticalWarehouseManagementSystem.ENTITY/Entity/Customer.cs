using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
   public class Customer:KernelEntity
    {
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        //public string TaxId { get; set; }
    
        public string Address { get; set; }
 
        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }
 
        public string Phone { get; set; }
      
        public string Fax { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

    }
}
