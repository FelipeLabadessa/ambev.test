using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer
{
    /// <summary>
    /// Handler for processing GetAllCustomerCommand requests
    /// </summary>
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerCommand, IEnumerable<GetAllCustomerResult>>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of GetAllCustomerHandler
        /// </summary>
        /// <param name="customerRepository">The customer repository</param>
        public GetAllCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Handles the GetAllCustomerCommand request
        /// </summary>
        /// <param name="request">The GetCustomer command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The customer details if found</returns>
        public async Task<IEnumerable<GetAllCustomerResult>> Handle(GetAllCustomerCommand request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync(cancellationToken);
            if (customers == null) throw new KeyNotFoundException($"Customers not found");
            List<GetAllCustomerResult> response = new List<GetAllCustomerResult>();

            foreach (var customer in customers) 
            {
                response.Add(new GetAllCustomerResult()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    CreatedAt = customer.CreatedAt,
                });
            }

            return response;
        }
    }
}