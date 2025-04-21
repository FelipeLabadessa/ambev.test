using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer;

/// <summary>
/// Command for retrieving all customers
/// </summary>
public record GetAllCustomerCommand : IRequest<IEnumerable<GetAllCustomerResult>>
{
    
}