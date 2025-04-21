using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    /// <summary>
    /// Profile for mapping UpdateCustomer feature results
    /// </summary>
    public class UpdateCustomerProfile : Profile
    {
        public UpdateCustomerProfile()
        {
            CreateMap<Customer, UpdateCustomerResult>();
        }
    }
}
