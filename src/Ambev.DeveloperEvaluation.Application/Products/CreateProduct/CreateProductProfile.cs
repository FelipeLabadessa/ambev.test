using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Profile for mapping CreateProduct feature results.
    /// </summary>
    public class CreateProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the class
        /// and defines the mappings for the CreateProduct feature.
        /// </summary>
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductResult>();
        }
    }
}
