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
    public sealed class PriceMapping : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("price", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("TEXT")
                .HasMaxLength(3)
                .IsRequired();

            builder.HasOne(e => e.Product)
                .WithOne(e => e.Price)
                .HasForeignKey<Product>(e => e.PriceId)
                .IsRequired();
        }
    }
}
