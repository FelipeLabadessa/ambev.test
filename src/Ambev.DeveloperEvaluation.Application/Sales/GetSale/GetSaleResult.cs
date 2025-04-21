namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}