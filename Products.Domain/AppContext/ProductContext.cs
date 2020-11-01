using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.AppContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 11 Pro",
                    Description = "Lastest Iphone 11 Pro, Now available for sale",
                    Price = 369000,
                    Category = "Phones & Tablets"

                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Umidigi A5 Pro",
                    Description = "New Umidigi Smartphone, very affordable",
                    Price = 49000,
                    Category = "Phones & Tablets"

                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Techo Hot 8 lite",
                    Description = "Latest tchno andriod phone",
                    Price = 38000,
                    Category = "Phones & Tablets"

                });

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    Password = "111111",
                    Email = "admin@yahoo.com",
                    Role = "Admin"

                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    Username = "user",
                    Password = "222222",
                    Email = "user@gmail.com",
                    Role = "User"

                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    Username = "stephen",
                    Password = "333333",
                    Email = "stephen@hotmail.com",
                    Role = "User"

                });

            ;
        }

    }
}
