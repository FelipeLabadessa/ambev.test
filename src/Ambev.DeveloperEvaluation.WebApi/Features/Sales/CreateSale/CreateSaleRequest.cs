namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    // <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the customer ID associated with the sale.
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the list of products and their quantities in the sale.
        /// </summary>
        public List<SaleProductRequest> Products { get; set; } = new List<SaleProductRequest>();

    }

    /// <summary>
    /// Represents a product in the sale and its quantity.
    /// </summary>
    public class SaleProductRequest
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product available or purchased.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public int Amount { get; set; }


        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}