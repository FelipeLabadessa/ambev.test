using Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer
{
    /// <summary>
    /// Profile for mapping UpdateCustomer feature requests and results
    /// </summary>
    public class UpdateCustomerProfile : Profile
    {
        public UpdateCustomerProfile()
        {
            CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>();
            CreateMap<UpdateCustomerResult, UpdateCustomerResponse>();
        }
    }
}
