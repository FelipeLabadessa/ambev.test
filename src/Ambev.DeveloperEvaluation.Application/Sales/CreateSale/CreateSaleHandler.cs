using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Handler for processing CreateSaleCommand requests.
    /// </summary>
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleHandler"/> class.
        /// This handler processes the creation of sales and manages related business logic.
        /// </summary>
        /// <param name="saleRepository">The repository for accessing and managing sales data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping data transfer objects to domain models.</param>
        /// <param name="saleProductRepository">The repository for managing products associated with a sale.</param>
        /// <param name="dbContext">The database context for managing transactions and database operations.</param>
        public CreateSaleHandler(
            ISaleRepository saleRepository, 
            IMapper mapper, 
            ISaleProductRepository saleProductRepository,
            DbContext dbContext)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _saleProductRepository = saleProductRepository;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Handles the CreateSaleCommand request.
        /// </summary>
        /// <param name="command">The CreateSale command containing the sale details.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>The result of the sale creation.</returns>
        /// <exception cref="ValidationException">Thrown when the command is invalid.</exception>
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            List<SaleProduct> saleProductList = GetSaleProductByCommand(command);
            var sale = _mapper.Map<Sale>(command);
            sale.SaleNumber = Guid.NewGuid();
            sale.Status = Domain.Enums.Sales.SaleStatus.Active;
            sale.TotalAmount = saleProductList.Sum(x => x.TotalPrice);
            sale.CreatedAt = DateTime.UtcNow;
            sale.Date = DateTime.UtcNow;

            using (var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
                    if (saleProductList != null && saleProductList.Count > 0)
                    {
                        saleProductList.ForEach(x => {
                            x.SaleId = createdSale.Id;
                        });

                        await _saleProductRepository.CreateBatchAsync(saleProductList, cancellationToken);
                    }

                    await transaction.CommitAsync(cancellationToken);
                    var result = new CreateSaleResult(createdSale, saleProductList!);

                    return result;
                }
                catch (Exception ex) 
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw new ApplicationException("An error occurred while processing the sale.", ex);
                }
            }
        }

        /// <summary>
        /// Maps the products from a <see cref="CreateSaleCommand"/> to a list of <see cref="SaleProduct"/> entities.
        /// This method processes each product from the command, calculates its total price,
        /// determines the discount tier, and applies the discount to the final price.
        /// </summary>
        /// <param name="command">
        /// The <see cref="CreateSaleCommand"/> containing the products and details for the sale.
        /// </param>
        /// <returns>
        /// A list of <see cref="SaleProduct"/> entities populated with calculated prices and discounts,
        /// ready to be associated with the sale.
        /// </returns>
        private List<SaleProduct> GetSaleProductByCommand(CreateSaleCommand command)
        {
            var saleProductList = new List<SaleProduct>();
            if (command.Products != null && command.Products.Count > 0)
            {
                command.Products.ForEach(x => {
                    var saleProduct = new SaleProduct()
                    {
                        ProductId = x.Id,
                        ProductName = x.Name,
                        Quantity = x.Amount,
                        CreatedAt = DateTime.UtcNow
                    };
                    saleProduct.CalculateTotalPrice(x.UnitPrice);
                    saleProduct.DetermineDiscountTier();
                    saleProduct.ApplyDiscountTierOnTotalPrice();

                    saleProductList.Add(saleProduct);
                });
            }
            return saleProductList;
        }
    }
}