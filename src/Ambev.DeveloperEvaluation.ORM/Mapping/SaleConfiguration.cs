using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuration for the Sale entity in the database.
    /// </summary>
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        /// <summary>
        /// Configures the Sale entity and its properties, relationships, and constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the Sale entity.</param>
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleNumber).IsRequired();
            builder.Property(s => s.Date).IsRequired();
            builder.Property(s => s.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(s => s.BranchId).IsRequired();

            builder.Property(s => s.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerID)
                .IsRequired() 
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Ignore(s => s.Products);
            builder.Ignore(s => s.AmountByItem);

            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);
        }
    }
}
