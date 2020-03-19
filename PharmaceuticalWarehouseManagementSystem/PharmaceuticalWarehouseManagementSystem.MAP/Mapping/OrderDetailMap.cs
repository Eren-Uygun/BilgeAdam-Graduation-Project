using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
    public class OrderDetailMap : KernelMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {


            builder.Property(x => x.UnitPrice).HasColumnType("decimal(5,3)").IsRequired(true);
            builder.Property(x => x.Quantity).IsRequired(true);
            builder.Property(x => x.Discount).HasColumnType("decimal(5,3)").IsRequired(true);




            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderID);


            builder.HasOne(x => x.Shipper)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ShipperID);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductID);


            base.Configure(builder);
        }
    }
}
