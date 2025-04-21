using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductPaged
{
    /// <summary>
    /// Command for retrieving a paged list of products.
    /// </summary>
    public record GetProductPagedCommand : IRequest<GetProductPagedResult>
    {
        public string? OrderBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}