using Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    /// <summary>
    /// Profile for mapping GetCustomer feature requests and results
    /// </summary>
    public class GetCustomerProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetCustomer feature
        /// </summary>
        public GetCustomerProfile()
        {
            CreateMap<Guid, GetCustomerCommand>()
                .ConstructUsing(id => new GetCustomerCommand(id));

            CreateMap<Domain.Entities.Sales.Customer, GetCustomerResult>();
        }
    }
}
