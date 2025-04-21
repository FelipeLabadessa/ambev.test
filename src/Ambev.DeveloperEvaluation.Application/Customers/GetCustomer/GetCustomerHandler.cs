using Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    /// <summary>
    /// Handler for processing GetCustomerCommand requests
    /// </summary>
    public class GetCustomerHandler : IRequestHandler<GetCustomerCommand, GetCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of GetCustomerHandler
        /// </summary>
        /// <param name="customerRepository">The customer repository</param>
        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Handles the GetCustomerCommand request
        /// </summary>
        /// <param name="request">The GetCustomer command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The customer details if found</returns>
        public async Task<GetCustomerResult> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customer == null)
                throw new KeyNotFoundException($"Customer with ID {request.Id} not found");

            return new GetCustomerResult
            {
                Id = customer.Id,
                Name = customer.Name
            };
        }
    }
}