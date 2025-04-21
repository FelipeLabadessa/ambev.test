using Ambev.DeveloperEvaluation.Domain.Repositories.Pagination;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductPaged
{
    /// <summary>
    /// Defines the mapping profiles for paged product retrieval operations.
    /// </summary>
    public class GetProductPagedProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the class
        /// and defines mappings between data transfer objects, commands, and response models.
        /// </summary>
        public GetProductPagedProfile()
        {
            CreateMap<PaginationRequestDTO, GetProductPagedCommand>();
        }
    }
}