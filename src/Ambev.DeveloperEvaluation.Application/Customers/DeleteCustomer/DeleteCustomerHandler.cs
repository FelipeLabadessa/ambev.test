using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    /// <summary>
    /// Handler for processing DeleteCustomerCommand requests
    /// </summary>
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISaleRepository _saleRepository;

        /// <summary>
        /// Instance for processing DeleteCustomerCommand requests
        /// </summary>
        /// <param name="customerRepository"></param>
        public DeleteCustomerHandler(
            ICustomerRepository customerRepository,
             ISaleRepository saleRepository)
        {
            _customerRepository = customerRepository;
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Handles the DeleteCustomerCommand request
        /// </summary>
        /// <param name="request">The DeleteCustomer command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The result of the delete operation</returns>
        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCustomerValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            var saleRelated = await _saleRepository.GetAllByCustomerId(request.Id, cancellationToken);
            if(saleRelated != null && saleRelated.Count() > 0) throw new DomainException("The customer cannot be deleted as they have associated sales.");

            var success = await _customerRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Customer with ID {request.Id} not found");

            return new DeleteCustomerResponse { Success = true };
        }
    }
}