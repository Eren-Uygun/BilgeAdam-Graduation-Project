using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
    public class OrderMap:KernelMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderDate).HasColumnType("datetime2").IsRequired(true);
            builder.Property(x => x.ShipAddress).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.ShipCity).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.ShippedDate).HasColumnType("datetime2").IsRequired(true);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.EmployeeID).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerID).OnDelete(DeleteBehavior.Cascade);










            base.Configure(builder);
        }

    }
}
