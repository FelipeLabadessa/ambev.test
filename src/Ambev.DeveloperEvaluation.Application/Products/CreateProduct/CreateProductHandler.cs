using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Handles the creation of a new product.
    /// </summary>
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="productRepository">The repository for product-related operations.</param>
        /// <param name="mapper">The AutoMapper instance for mapping objects.</param>
        public CreateProductHandler(
            IProductRepository productRepository, 
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the creation of a new product.
        /// </summary>
        /// <param name="command">The command containing the details of the product to be created.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
        /// <returns>A <see cref="CreateProductResult"/> indicating the result of the operation.</returns>
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            Product product = _mapper.Map<Product>(command);
            await _productRepository.CreateAsync(product, cancellationToken);
            
            return new CreateProductResult
            {
                Id = product.Id,
                Name = product.Name
            };
        }
    }
}