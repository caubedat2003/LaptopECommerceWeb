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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the one-to-many relationship
        }
    }
}
