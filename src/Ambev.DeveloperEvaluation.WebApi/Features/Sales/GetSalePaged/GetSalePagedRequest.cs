namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSalePaged
{
    /// <summary>
    /// Request model for retrieving a sale by ID
    /// </summary>
    public class GetSalePagedRequest
    {
        /// <summary>
        /// The unique identifier of the sale to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}
