using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Profile for mapping CreateCustomer feature results
    /// </summary>
    public class CreateCustomerProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCustomer feature
        /// </summary>
        public CreateCustomerProfile()
        {
            // Maps a Customer entity to CreateCustomerResult
            CreateMap<Customer, CreateCustomerResult>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}