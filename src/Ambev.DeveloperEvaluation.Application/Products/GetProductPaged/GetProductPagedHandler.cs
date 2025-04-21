using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductPaged
{
    /// <summary>
    /// Handler for processing GetProductPagedPagedCommand requests.
    /// </summary>
    public class GetProductPagedHandler : IRequestHandler<GetProductPagedCommand, GetProductPagedResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetProductPagedHandler.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GetProductPagedHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductPagedPagedCommand request.
        /// </summary>
        /// <param name="request">The GetProductPaged command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The product details if found.</returns>
        public async Task<GetProductPagedResult> Handle(GetProductPagedCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetProductPagedValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            var totalRecords = await _productRepository.GetTotalRecordsAsync();
            var products = await _productRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
            if (products == null) throw new KeyNotFoundException($"No products registered in the system yet.");

            var result = new GetProductPagedResult(request, totalRecords, products.ToList());
            return result;
        }
    }
}
