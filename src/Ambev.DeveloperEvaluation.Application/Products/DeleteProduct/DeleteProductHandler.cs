﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    /// <summary>
    /// Handler for processing DeleteProductCommand requests.
    /// </summary>
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of DeleteProductHandler.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the DeleteProductCommand request.
        /// </summary>
        /// <param name="request">The DeleteProductCommand.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The result of the delete operation.</returns>
        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // Validate the command
            var validator = new DeleteProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Attempt to delete the product from the repository
            var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);

            if (!success)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");
            }

            // Return success response
            return new DeleteProductResponse { Success = true };
        }
    }
}
