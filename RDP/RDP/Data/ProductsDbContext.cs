using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RDP.Models
{
    // 4
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext (DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(

                new Products
                {
                    Id = "1",
                    SKU = "1234",
                    Name = "Chocolate",
                    Description = "Dark",
                    Price = 2.99m,
                    Quantity = 100

                }

                );

        }

        public DbSet<RDP.Models.Products> Products { get; set; }
    }
}
