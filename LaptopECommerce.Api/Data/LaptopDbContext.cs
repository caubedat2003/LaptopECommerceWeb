using LaptopECommerce.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaptopECommerce.Api.Data
{
    public class LaptopDbContext : IdentityDbContext<User, Role, Guid>
    {
        public LaptopDbContext(DbContextOptions<LaptopDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLaptop> OrderLaptops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderLaptops)
            .WithOne(ol => ol.Order)
            .HasForeignKey(ol => ol.OrderId);

            // Cấu hình quan hệ 1-n giữa Laptop và OrderLaptop
            modelBuilder.Entity<Laptop>()
                .HasMany(l => l.OrderLaptops)
                .WithOne(ol => ol.Laptop)
                .HasForeignKey(ol => ol.LaptopId);
        }
    }
}
