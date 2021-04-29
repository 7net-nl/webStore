using ElectroShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Infrasctures.Data.Ef.Configurations
{
    public class FileConfig : IEntityTypeConfiguration<FFiles>
    {
        public void Configure(EntityTypeBuilder<FFiles> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.FileName).HasMaxLength(1000).IsRequired();
            builder.Property(c => c.FileType).HasMaxLength(10);
            builder.Property(c => c.Path).HasMaxLength(2000);
            builder.Property(c => c.Product_ID).IsRequired();
            
        }
    }
}
