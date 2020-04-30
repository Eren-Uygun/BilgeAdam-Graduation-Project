using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
    public class Supplier:KernelEntity
    {

        [Required(ErrorMessage = "Please Enter CompanyName")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please Enter ContactName")]
        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please Enter your Tax Id Number"),MaxLength(10)]
        public string TaxIdNumber { get; set; }
        [Required(ErrorMessage ="Please Enter PhoneNumber")]
        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
