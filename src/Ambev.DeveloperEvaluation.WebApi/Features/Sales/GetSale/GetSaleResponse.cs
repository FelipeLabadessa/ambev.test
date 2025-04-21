namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// API response model for GetSale operation.
    /// </summary>
    public class GetSaleResponse
    {
        /// <summary>
        /// The unique identifier of the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier (SaleNumber) for the sale.
        /// </summary>
        public Guid SaleNumber { get; set; }

        /// <summary>
        /// The date when the sale was made.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The current status of the sale.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The ID of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// The customer associated with the sale.
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// A list of products in the sale.
        /// </summary>
        public List<SaleProductResponse> Products { get; set; } = new();

        /// <summary>
        /// The date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date and time of the last update to the sale's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Represents the product details in a sale.
    /// </summary>
    public class SaleProductResponse
    {
        /// <summary>
        /// The unique identifier of the product in the sale.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity of the product in the sale.
        /// </summary>
        public int Ammount { get; set; }

        /// <summary>
        /// The total price of the product in the sale.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }

}