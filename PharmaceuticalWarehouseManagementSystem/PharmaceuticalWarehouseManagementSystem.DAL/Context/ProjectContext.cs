using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using PharmaceuticalWarehouseManagementSystem.MAP.Mapping;
using PharmaceuticalWarehouseManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;

namespace PharmaceuticalWarehouseManagementSystem.DAL.Context
{
   public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new OrderDetailMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ShipperMap());
            modelBuilder.ApplyConfiguration(new SupplierMap());


            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        public override int SaveChanges()
        {

            var modifiedEntites = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string computerName = Environment.MachineName;
            string ipAddress = Ipfinder.GetIpAddress(); /*"127.0.0.1";*/
            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntites)
            {
                KernelEntity entity = item.Entity as KernelEntity;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIP = ipAddress;
                            entity.CreatedDate = date;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedIP = ipAddress;
                            entity.ModifiedDate = date;
                            break;
                        default:
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }

}

