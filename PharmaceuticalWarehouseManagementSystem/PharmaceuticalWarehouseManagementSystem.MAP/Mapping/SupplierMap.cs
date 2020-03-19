using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
   public class SupplierMap:KernelMap<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ContactName).HasMaxLength(20).IsRequired(true);
            builder.Property(x => x.ContactTitle).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired(true);

            builder.Property(x => x.Address).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.City).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Region).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.HomePage).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Country).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.FaxNumber).HasMaxLength(20).IsRequired(false);





            builder.HasMany(x => x.Products)
                .WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierID);





            base.Configure(builder);
        }
    }
}
