using Ambev.DeveloperEvaluation.Domain.Enums.Sales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Request model for creating a new product
    /// </summary>
    public class CreateProductRequest
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// Represents the total number of units.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// Represents the cost of a single unit in decimal format.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}