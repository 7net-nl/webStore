using ElectroShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Infrasctures.Data.Ef.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(1000).IsRequired();
            builder.Property(c => c.City).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Country).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(4000).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(500).IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
            
           


        }
    }
}
