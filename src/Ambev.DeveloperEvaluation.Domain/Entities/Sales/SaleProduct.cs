using Ambev.DeveloperEvaluation.Domain.Enums.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    /// <summary>
    /// Represents the association between a sale and a product.
    /// </summary>
    public class SaleProduct
    {
        /// <summary>
        /// The ID of the sale.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// The sale entity.
        /// </summary>
        public Sale? Sale { get; set; } = null!;

        /// <summary>
        /// The ID of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; } = null!;

        /// <summary>
        /// The product entity.
        /// </summary>
        public Product Product { get; set; } = null!;

        /// <summary>
        /// The quantity of the product in the sale.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The total price for this product in the sale.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount tier.
        /// </summary>
        public DiscountTier DiscountTier { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the last update to the product.
        /// This property is optional and may be null if no updates have been made.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Calculates the total price for the sale product.
        /// </summary>
        public void CalculateTotalPrice(decimal unitPrice)
        {
            TotalPrice = Quantity * unitPrice;
        }

        /// <summary>
        /// Determines the discount tier based on the quantity.
        /// </summary>
        public void DetermineDiscountTier()
        {
            if (Quantity >= 10 && Quantity <= 20)
            {
                DiscountTier = DiscountTier.TwentyPercent;
            }
            else if (Quantity >= 4)
            {
                DiscountTier = DiscountTier.TenPercent;
            }
            else
            {
                DiscountTier = DiscountTier.NoDiscount;
            }
        }

        /// <summary>
        /// Applies the discount tier to the total price.
        /// </summary>
        public void ApplyDiscountTierOnTotalPrice()
        {
            var discountMultiplier = 1 - ((decimal)DiscountTier / 100);
            TotalPrice *= discountMultiplier;
        }

        /// <summary>
        /// Constructor for  automapper, entity, etc..
        /// </summary>
        public SaleProduct()
        {
            
        }
    }
}