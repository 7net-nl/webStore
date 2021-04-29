using ElectroShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Infrasctures.Data.Ef.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Color).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.DiscountPrice);
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Rate);
            builder.Property(c => c.Size).IsRequired();
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Type).IsRequired();

            builder.HasOne(c => c.Category).WithMany().HasForeignKey(c => c.Category_ID).HasPrincipalKey(c => c.ID).IsRequired();
            builder.HasMany(c => c.Images).WithOne(c => c.Product).HasForeignKey(c => c.Product_ID).HasPrincipalKey(c => c.ID);
        }
    }
}
