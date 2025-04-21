using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.Sales.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Sales
{
    /// <summary>
    /// Contains unit tests for the Sale entity class.
    /// Tests cover status changes, validation scenarios, and business rules.
    /// </summary>
    public class SaleTests
    {
        /// <summary>
        /// Tests that a sale's status changes to Cancelled when it is cancelled.
        /// </summary>
        [Fact(DisplayName = "Sale status should change to Cancelled when cancelled")]
        public void Given_ActiveSale_When_Cancelled_Then_StatusShouldBeCancelled()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.Status = SaleStatus.Active;

            // Act
            sale.Cancel();

            // Assert
            Assert.Equal(SaleStatus.Cancelled, sale.Status);
        }

        [Fact(DisplayName = "Total amount should match the sum of product prices times their quantities")]
        public void Given_ValidSale_When_CalculatingTotalAmount_Then_ShouldMatchSumOfProducts()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var products = ProductTestData.GenerateValidProducts(3);
            sale.Products = products.Select(p => new SaleProduct
            {
                SaleId = sale.Id,
                ProductId = p.Id,
                Product = p,
                Quantity = 2,
                TotalPrice = p.UnitPrice * 2 
            }).ToList();

            sale.AmountByItem = products.ToDictionary(p => p.Id, _ => 2);

            var expectedTotal = sale.Products.Sum(sp => sp.Product.UnitPrice * sale.AmountByItem[sp.ProductId]);

            // Act
            sale.CalculateTotalAmount();

            // Assert
            Assert.Equal(expectedTotal, sale.TotalAmount);
        }

        /// <summary>
        /// Tests that validation fails for a sale with invalid data.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for a sale with invalid data")]
        public void Given_InvalidSale_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var sale = new Sale
            {
                SaleNumber = Guid.Empty,
                CustomerID = Guid.Empty,
                TotalAmount = -100, 
                BranchId = Guid.Empty,
                Products = null, 
                AmountByItem = null,
                Status = SaleStatus.Unknown 
            };

            // Act
            var result = sale.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        /// <summary>
        /// Tests that CalculateTotalAmount calculates the total correctly when Products and AmountByItem are valid.
        /// </summary>
        [Fact(DisplayName = "Should calculate total amount correctly when Products and AmountByItem are valid")]
        public void Given_ValidProductsAndAmountByItem_When_CalculatingTotalAmount_Then_ShouldReturnCorrectTotal()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var products = ProductTestData.GenerateValidProducts(2);
            var saleProducts = ProductTestData.GenerateValidSaleProducts(products, quantity: 2).ToList();

            sale.Products = saleProducts;
            sale.AmountByItem = saleProducts.ToDictionary(p => p.ProductId, p => p.Quantity);
            var expectedTotal = saleProducts.Sum(p => p.TotalPrice);

            // Act
            sale.CalculateTotalAmount();

            // Assert
            Assert.Equal(expectedTotal, sale.TotalAmount);
        }

        /// <summary>
        /// Tests that CalculateTotalAmount throws an exception when Products or AmountByItem is null.
        /// </summary>
        [Fact(DisplayName = "Should throw InvalidOperationException if Products or AmountByItem is null")]
        public void Given_NullProductsOrAmountByItem_When_CalculatingTotalAmount_Then_ShouldThrowException()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.Products = null;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sale.CalculateTotalAmount());

            // Arrange
            var products = ProductTestData.GenerateValidProducts(2);
            sale.Products = ProductTestData.GenerateValidSaleProducts(products, quantity: 2).ToList();
            sale.AmountByItem = null;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sale.CalculateTotalAmount());
        }

        /// <summary>
        /// Tests that Cancel throws an InvalidOperationException when the sale is not Active.
        /// </summary>
        [Fact(DisplayName = "Should throw InvalidOperationException when cancelling a sale that is not Active")]
        public void Given_NonActiveSale_When_Cancelling_Then_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.Status = SaleStatus.Cancelled; 

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => sale.Cancel());
            Assert.Equal("Only active sales can be cancelled.", exception.Message);
        }
    }
}
