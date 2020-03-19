﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
   public class EmployeeMap:KernelMap<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Role).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.BirthDate).HasColumnType("datetime2").IsRequired(false);
            builder.Property(x => x.HireDate).HasColumnType("datetime2").IsRequired(false);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(16).IsRequired(true);
            builder.Property(x => x.Address).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.City).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.Region).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.Country).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.PostalCode).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Role);


            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeID);



            base.Configure(builder);
        }
    }
}
