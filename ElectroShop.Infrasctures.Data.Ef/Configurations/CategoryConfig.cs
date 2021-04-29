using ElectroShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Infrasctures.Data.Ef.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(500).IsRequired();
        }
    }
}
