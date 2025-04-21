using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Provides configuration for the Customer entity in the database.
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configures the Customer entity and its properties, relationships, and constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the Customer entity.</param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.UpdatedAt).IsRequired(false);

            builder.HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
