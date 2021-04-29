using ElectroShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Infrasctures.Data.Ef.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.Product_ID).HasPrincipalKey(c => c.ID).IsRequired();
            builder.HasOne(c => c.Customer).WithMany(c => c.Orders).HasForeignKey(c => c.Customer_ID).HasPrincipalKey(c => c.ID).IsRequired();
            
        }
    }
}
