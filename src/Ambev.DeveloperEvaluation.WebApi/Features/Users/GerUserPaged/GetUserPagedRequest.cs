namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GerUserPaged
{
    /// <summary>
    /// Request model for retrieving a product by ID
    /// </summary>
    public class GetUserPagedRequest
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}
