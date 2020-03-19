using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Map;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PharmaceuticalWarehouseManagementSystem.MAP.Mapping
{
   public class CategoryMap:KernelMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x => x.CategoryName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.CategoryDescription).HasMaxLength(255).IsRequired(false);


            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Cascade);




            base.Configure(builder);
        }
    }
}
