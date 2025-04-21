using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    /// <summary>
    /// Handler for processing UpdateCustomerCommand requests
    /// </summary>
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingCustomer = await _customerRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingCustomer == null)
                throw new KeyNotFoundException("Customer not found");

            existingCustomer.Name = command.Name;
            existingCustomer.UpdatedAt = DateTime.UtcNow;

            await _customerRepository.UpdateAsync(existingCustomer, cancellationToken);

            return new UpdateCustomerResult
            {
                Id = existingCustomer.Id,
                Name = existingCustomer.Name,
                UpdatedAt = existingCustomer.UpdatedAt
            };
        }
    }
}
