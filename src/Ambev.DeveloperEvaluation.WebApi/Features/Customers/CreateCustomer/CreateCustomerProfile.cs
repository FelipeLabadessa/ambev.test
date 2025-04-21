using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    /// <summary>
    /// Profile for mapping CreateCustomer feature requests and results
    /// </summary>
    public class CreateCustomerProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCustomer feature
        /// </summary>
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
            CreateMap<CreateCustomerResult, CreateCustomerResponse>();
        }
    }
}
