using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{

    /// <summary>
    /// Represents the response returned after successfully creating a new sale.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created sale,
    /// along with details about the sale and the associated products.
    /// </remarks>
    public class CreateSaleResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created sale in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created sale in the system.</value>
        public Guid SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the sale.
        /// </summary>
        /// <value>The total monetary value of the sale.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale was created.
        /// </summary>
        /// <value>The date and time of the sale creation.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products associated with the sale.
        /// </summary>
        /// <value>A collection of products included in the sale.</value>
        public List<SaleProductResult> Products { get; set; } = new List<SaleProductResult>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleResult"/> class.
        /// </summary>
        /// <param name="sale">The created sale entity.</param>
        /// <param name="products">The list of products associated with the sale.</param>
        public CreateSaleResult(Sale sale, List<SaleProduct> products)
        {
            Id = sale.Id;
            TotalAmount = sale.TotalAmount;
            Date = sale.CreatedAt;
            SaleNumber = sale.SaleNumber;
            Products = products.Select(product => new SaleProductResult
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                TotalPrice = product.TotalPrice,
                DiscountTier = product.DiscountTier.ToString()
            }).ToList();
        }

        /// <summary>
        /// AutoMapper, entityFMWK constructor
        /// </summary>
        public CreateSaleResult()
        {
            
        }
    }

    /// <summary>
    /// Represents a product associated with a sale.
    /// </summary>
    public class SaleProductResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the quantity of the product in the sale.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total price for the product (after applying discounts).
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount tier applied to the product.
        /// </summary>
        public string DiscountTier { get; set; } = null!;
    }
}