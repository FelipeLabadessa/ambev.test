using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Command for creating a new product
    /// </summary>
    public class CreateProductCommand : IRequest<CreateProductResult>
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

        /// <summary>
        /// Gets or sets the discount tier for the product.
        /// Determines the discount category applied to this product.
        /// </summary>
        public DiscountTier DiscountTier { get; set; }
    }
}