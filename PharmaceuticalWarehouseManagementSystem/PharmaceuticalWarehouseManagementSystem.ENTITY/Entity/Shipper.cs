using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
   public class Shipper:KernelEntity
    {
    
        [Required(ErrorMessage =" Please Enter Shipper Company Name")]
        public string CompanyName { get; set; }
        [MaxLength(10),Required(ErrorMessage ="Please Enter Tax Id"),MinLength(10)]
        public string TaxIdNumber { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
