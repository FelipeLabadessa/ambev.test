using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests
{
    /// <summary>
    /// Contains unit tests for the CreateSaleProfile mappings.
    /// </summary>
    public class CreateSaleProfileTests
    {
        private readonly IMapper _mapper;

        public CreateSaleProfileTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CreateSaleProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        /// <summary>
        /// Tests that CreateSaleCommand maps correctly to Sale.
        /// </summary>
        [Fact(DisplayName = "Should map CreateSaleCommand to Sale correctly")]
        public void Given_CreateSaleCommand_When_MappedTo_Sale_Then_MapsCorrectly()
        {
            // Arrange
            var command = new CreateSaleCommand
            {

                CustomerID = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                Products = new List<SaleProductCommand>()

            };

            // Act
            var sale = _mapper.Map<Sale>(command);

            // Assert
            Assert.NotNull(sale);
            Assert.Equal(command.CustomerID, sale.CustomerID);
            Assert.Equal(command.BranchId, sale.BranchId);
            Assert.Equivalent(command.Products, sale.Products);
        }

        /// <summary>
        /// Tests that Sale maps correctly to CreateSaleResult.
        /// </summary>
        [Fact(DisplayName = "Should map Sale to CreateSaleResult correctly")]
        public void Given_Sale_When_MappedTo_CreateSaleResult_Then_MapsCorrectly()
        {
            // Arrange
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                TotalAmount = 200
            };

            // Act
            var result = _mapper.Map<CreateSaleResult>(sale);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sale.Id, result.Id);
            Assert.Equal(sale.TotalAmount, result.TotalAmount);
        }
    }
}
