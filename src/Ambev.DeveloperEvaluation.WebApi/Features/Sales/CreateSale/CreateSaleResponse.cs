namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
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
    }
}
