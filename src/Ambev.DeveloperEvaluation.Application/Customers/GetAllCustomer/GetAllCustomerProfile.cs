using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer
{
    /// <summary>
    /// Profile for mapping GetAllCustomer feature requests and results
    /// </summary>
    public class GetAllCustomerProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetAllCustomer feature
        /// </summary>
        public GetAllCustomerProfile()
        {
            CreateMap<Domain.Entities.Sales.Customer, GetAllCustomerResult>();
        }
    }
}