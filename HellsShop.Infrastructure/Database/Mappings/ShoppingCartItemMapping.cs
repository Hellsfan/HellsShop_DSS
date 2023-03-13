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
    public sealed class ShoppingCartItemMapping : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("shopping_cart_item", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(e => e.PriceId)
                .HasColumnName("price_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(e => e.ShoppingCartId)
                .HasColumnName("shopping_cart_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.HasOne(e => e.ShoppingCart)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.ShoppingCartId);

            builder.HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Price)
                .WithOne()
                .HasForeignKey<ShoppingCartItem>(e => e.PriceId);
        }
    }
}
