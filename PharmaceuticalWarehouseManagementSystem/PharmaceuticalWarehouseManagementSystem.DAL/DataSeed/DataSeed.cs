using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;

namespace PharmaceuticalWarehouseManagementSystem.DAL.DataSeed
{
   public static class DataSeed
    {
       public static void Seed(this ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    ID = new Guid(),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Role = Role.Admin,
                    Email = "admin@mail.com",
                    Password = "123",
                    BirthDate = DateTime.Parse("10/11/2020 17:00"),
                    HireDate = DateTime.Parse("24/02/2020 09:05")
                },

                new Employee()
                {
                    ID = new Guid(),
                    FirstName = "User",
                    LastName = "User",
                    Role = Role.User,
                    Email = "user@mail.com",
                    Password = "123",
                    BirthDate = DateTime.Parse("10/11/2020 17:00"),
                    HireDate = DateTime.Parse("24/02/2020 09:05")
                }

            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = new Guid(),
                    CategoryName = "Ağrı kesici",
                    CategoryDescription = "Düşük ve orta düzey ağrı giderici ilaçlar"
                },

                new Category()
                {
                    ID = new Guid(),
                    CategoryName = "Ateş Düşürücü",
                    CategoryDescription = "Vücut sıcaklığını ayarlamaya yarayan ilaçlar"
                }

            );


        }
    }
}
