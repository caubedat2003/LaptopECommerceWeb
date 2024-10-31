using LaptopECommerce.Api.Entities;
using Microsoft.AspNetCore.Identity;

namespace LaptopECommerce.Api.Data
{
    public class LaptopDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(LaptopDbContext context, ILogger<LaptopDbContextSeed> logger)
        {
            if(!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Admin",
                    LastName = "Mr",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0123456789",
                    UserName = "admin",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin123@");
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
