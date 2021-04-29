using ElectroShop.Domain.Entities;
using ElectroShop.Infrasctures.Data.Ef.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ElectroShop.Infrasctures.Data.Ef
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<FFiles> Files { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new FileConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());

            modelBuilder.Seed();

            
            base.OnModelCreating(modelBuilder);
        }

       

    }
}
