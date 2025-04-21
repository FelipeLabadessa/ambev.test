using Ambev.DeveloperEvaluation.Application.Products.GetProductPaged;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUserPaged
{
    /// <summary>
    /// Command for retrieving a paged list of products.
    /// </summary>
    public record GetUserPagedCommand : IRequest<GetUserPagedResult>
    {
        public string? OrderBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
