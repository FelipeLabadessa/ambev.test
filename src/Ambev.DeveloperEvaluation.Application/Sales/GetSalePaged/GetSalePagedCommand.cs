using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged
{
    /// <summary>
    /// Command for retrieving a paged list of Sales.
    /// </summary>
    public record GetSalePagedCommand : IRequest<GetSalePagedResult>
    {
        public string? OrderBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
