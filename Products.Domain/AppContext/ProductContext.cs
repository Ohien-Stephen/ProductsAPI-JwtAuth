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

                });
            ;
        }

    }
}
