using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
    public class Employee : KernelEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }


        public string Address { get; set; }
        public string City { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string HomePhoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        public string Notes { get; set; }

        public string Photo { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName+" "+this.LastName; }
            set { ; }
        }

    }

}

