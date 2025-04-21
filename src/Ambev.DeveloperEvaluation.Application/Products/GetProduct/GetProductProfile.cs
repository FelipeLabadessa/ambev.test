using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    /// <summary>
    /// Profile for mapping GetProduct feature results.
    /// </summary>
    public class GetProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// and defines the mappings for the GetProduct feature.
        /// </summary>
        public GetProductProfile()
        {
            CreateMap<Product, GetProductResult>();
        }
    }
}