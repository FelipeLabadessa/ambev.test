using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuration for the SaleProduct entity in the database.
    /// </summary>
    public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        /// <summary>
        /// Configures the SaleProduct entity and its properties, relationships, and constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the SaleProduct entity.</param>
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.ToTable("SaleProducts");

            builder.HasKey(sp => new { sp.SaleId, sp.ProductId });

            builder.HasOne(sp => sp.Sale)
                .WithMany(s => s.Products)
                .HasForeignKey(sp => sp.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sp => sp.Product)
                .WithMany()
                .HasForeignKey(sp => sp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(sp => sp.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sp => sp.Quantity).IsRequired();
            builder.Property(sp => sp.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(sp => sp.DiscountTier)
                .HasConversion<string>() 
                .HasMaxLength(50)
                .HasDefaultValue(DiscountTier.NoDiscount)
                .IsRequired();

            builder.Property(sp => sp.CreatedAt)
               .IsRequired();

            builder.Property(sp => sp.UpdatedAt)
              .IsRequired(false);
        }
    }
}