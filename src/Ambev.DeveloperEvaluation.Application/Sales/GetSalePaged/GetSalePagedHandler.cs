using Ambev.DeveloperEvaluation.Application.Products.GetProductPaged;
using Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged
{
    /// <summary>
    /// Handler for processing GetProductPagedPagedCommand requests.
    /// </summary>
    public class GetSalePagedHandler : IRequestHandler<GetSalePagedCommand, GetSalePagedResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetProductPagedHandler.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GetSalePagedHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductPagedPagedCommand request.
        /// </summary>
        /// <param name="request">The GetProductPaged command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The product details if found.</returns>
        public async Task<GetSalePagedResult> Handle(GetSalePagedCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetSalePagedValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var totalRecords = await _saleRepository.GetTotalRecordsAsync();
            var sales = await _saleRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
            if (sales == null || !sales.Any())
                throw new KeyNotFoundException($"No sales registered in the system yet.");

            var mapped = _mapper.Map<List<SaleResponse>>(sales);
            var result = new GetSalePagedResult(request, totalRecords, mapped);
            return result;
        }
    }
}
