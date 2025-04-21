using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GerUserPaged
{
    /// <summary>
    /// Represents the response model for retrieving a product's details.
    /// </summary>
    public class GetUserPagedResponse
    {
        public PaginatedResponse<User> response;
    }
}
