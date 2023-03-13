using HellsShop.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsShop.Infrastructure.Database.Mappings
{
    public sealed class ShoppingCartMapping : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("shopping_cart", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.TotalPrice)
                .HasColumnName("total_price")
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("TEXT")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("INTEGER")
                .HasDefaultValue(ShoppingCartStatus.Pending)
                .HasConversion<ShoppingCartStatus>();

            builder.HasMany(e => e.Items)
                 .WithOne(e => e.ShoppingCart)
                 .HasForeignKey(e => e.ShoppingCartId);
        }
    }
}
