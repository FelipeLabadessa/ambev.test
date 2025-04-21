using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSalePaged
{
    /// <summary>
    /// Represents the response model for retrieving a sale's details.
    /// </summary>
    public class GetSalePagedResponse
    {
        public PaginatedResponse<Sale> response;
    }
}
