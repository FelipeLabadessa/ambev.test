using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests
{
    /// <summary>
    /// Contains unit tests for the GetSaleProfile mappings.
    /// </summary>
    public class GetSaleProfileTests
    {
        private readonly IMapper _mapper;

        public GetSaleProfileTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetSaleProfile>();
            });

            _mapper = configuration.CreateMapper();
            configuration.AssertConfigurationIsValid(); // Verifies mapping configurations
        }

        /// <summary>
        /// Tests that Sale maps correctly to GetSaleResult.
        /// </summary>
        [Fact(DisplayName = "Should map Sale to GetSaleResult correctly")]
        public void Given_Sale_When_MappedTo_GetSaleResult_Then_MapsCorrectly()
        {
            // Arrange
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                TotalAmount = 500
            };

            // Act
            var result = _mapper.Map<GetSaleResult>(sale);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sale.Id, result.Id);
            Assert.Equal(sale.TotalAmount, result.TotalAmount);
        }
    }
}