using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductPaged
{
    /// <summary>
    /// Represents the response model for retrieving a product's details.
    /// </summary>
    public class GetProductPagedResponse
    {
        public PaginatedResponse<Product> response ;
    }
}