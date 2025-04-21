namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductPaged
{
    /// <summary>
    /// Request model for retrieving a product by ID
    /// </summary>
    public class GetProductPagedRequest
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}