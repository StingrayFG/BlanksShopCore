using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Linq;
using System.Text;
using System.IO;
using Domain.Entities;
using Infrastructure.EntitiesEF;
using System.Numerics;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MetalBlankEF> MetalBlanks { get; set; }
        public DbSet<ShoppingCartEF> ShoppingCarts { get; set; }
        public DbSet<OrderEF> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql("Host=localhost; Database=BlanksShop; Username=postgres; Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartEF>()
            .HasKey(nameof(ShoppingCartEF.ID), nameof(ShoppingCartEF.ProductID));
        }


    }
}
