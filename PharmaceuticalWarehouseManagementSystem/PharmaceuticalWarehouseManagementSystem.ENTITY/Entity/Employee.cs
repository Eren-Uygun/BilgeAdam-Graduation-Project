using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PharmaceuticalWarehouseManagementSystem.ENTITY.Entity
{
    public class Employee : KernelEntity
    {

        [Required(ErrorMessage = "Please Enter Your Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Surname")]
        public string LastName { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter your Birthdate"),DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Hire Date must be required"),DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        public string PhoneNumber { get; set; }

        [
            EmailAddress(ErrorMessage = "example@mail.com"),
            Required(ErrorMessage = "Please Enter Your Email")

        ]

        public string Email { get; set; }
        [
            Required(ErrorMessage = "Entered Wrong Password"),DataType(DataType.Password)
        ]
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string imageUrl { get; set; }

        [Required(ErrorMessage = "Please Select your role")]
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

