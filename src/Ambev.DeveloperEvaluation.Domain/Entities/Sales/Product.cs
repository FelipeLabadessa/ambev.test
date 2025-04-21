using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    /// <summary>
    /// Represents a product entity.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the product available or purchased.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// Represents the cost of a single unit in decimal format.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

    }
}