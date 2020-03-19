using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
   public class CustomerMap:KernelMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ContactName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ContactTitle).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Country).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.Region).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.City).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.Address).HasMaxLength(80).IsRequired(false);
            builder.Property(x => x.Phone).HasMaxLength(20).IsRequired(true);
            builder.Property(x => x.Fax).HasMaxLength(20).IsRequired(false);


            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerID);

            base.Configure(builder);
        }
    }
}
