using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
    public class ShipperMap : KernelMap<Shipper>
    {
        public override void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50).IsRequired(true);

            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Shipper)
                .HasForeignKey(x => x.ShipperID);

            base.Configure(builder);
        }
    }
}
