using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
   public class ProductMap:KernelMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(x => x.ProductName).HasMaxLength(20).IsRequired(true);
            builder.Property(x => x.QuantityPerUnit).IsRequired(true);
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(5,3)").IsRequired(true);
            builder.Property(x => x.UnitsInStock).IsRequired(true);
            builder.Property(x => x.Discontinued).IsRequired(true);
           
            builder.Property(x => x.ExpiredDate).HasColumnType("datetime2").IsRequired(true);
            builder.Property(x => x.ReorderLevel).IsRequired(true);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products) // CAT
                .HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Products) // Sup
                .HasForeignKey(x => x.SupplierID);









            base.Configure(builder);
        }
    }
}
