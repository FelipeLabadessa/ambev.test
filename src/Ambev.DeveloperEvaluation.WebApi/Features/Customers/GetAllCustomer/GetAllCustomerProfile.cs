using Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer
{
    /// <summary>
    /// Profile for mapping GetAllCustomer feature requests to commands
    /// </summary>
    public class GetAllCustomerProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetAllCustomer feature
        /// </summary>
        public GetAllCustomerProfile()
        {
            CreateMap<GetAllCustomerRequest, GetAllCustomerCommand>();
            CreateMap<GetAllCustomerResponse, GetAllCustomerResult>();
            CreateMap<IEnumerable<GetAllCustomerResult>, IEnumerable<GetAllCustomerResponse>>();
        }
    }
}