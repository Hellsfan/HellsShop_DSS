using HellsShop.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsShop.Infrastructure.Database.Configuration
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=HellDatabse.db", config =>
                {
                    config.MigrationsAssembly("HellsShop.Infrastructure");
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
