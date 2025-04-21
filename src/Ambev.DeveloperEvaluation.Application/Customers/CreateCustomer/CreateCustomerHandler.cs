using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Handler for processing CreateCustomerCommand requests
    /// </summary>
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of CreateCustomerHandler
        /// </summary>
        /// <param name="customerRepository">The customer repository</param>
        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Handles the CreateCustomerCommand request
        /// </summary>
        /// <param name="command">The CreateCustomer command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The result of the customer creation</returns>
        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            var customer = new Customer
            {
                Name = command.Name,
                CreatedAt = DateTime.UtcNow
            };

            var createdCustomer = await _customerRepository.CreateAsync(customer, cancellationToken);

            return new CreateCustomerResult
            {
                Id = createdCustomer.Id,
                Name = createdCustomer.Name,
                CreatedAt = createdCustomer.CreatedAt,
            };
        }
    }
}
