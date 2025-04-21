using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Handler for processing DeleteSaleCommand requests
    /// </summary>
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        /// <summary>
        /// Initializes a new instance of DeleteSaleHandler
        /// </summary>
        /// <param name="saleRepository">The repository used to interact with the sales database.</param>
        public DeleteSaleHandler(
            ISaleRepository saleRepository
        )
        {
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Handles the deletion of a sale based on the provided command.
        /// </summary>
        /// <param name="request">The command containing the ID of the sale to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A response indicating whether the deletion was successful.</returns>
        /// <exception cref="ValidationException">Thrown if the request fails validation.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the sale with the specified ID is not found.</exception>
        public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success) throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

            return new DeleteSaleResponse { Success = true };
        }
    }
}