using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests
{
    public class GetSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepositorySubstitute;
        private readonly IMapper _mapperSubstitute;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepositorySubstitute = Substitute.For<ISaleRepository>();
            _mapperSubstitute = Substitute.For<IMapper>();
            _handler = new GetSaleHandler(_saleRepositorySubstitute, _mapperSubstitute);
        }

        /// <summary>
        /// Tests that a valid GetSaleCommand returns the correct sale details.
        /// </summary>
        [Fact(DisplayName = "Should return sale details when valid command is provided")]
        public async Task Given_ValidCommand_When_HandleCalled_Then_ShouldReturnSaleDetails()
        {
            // Arrange
            var validCommand = new GetSaleCommand(Guid.NewGuid());
            var sale = new Sale { Id = validCommand.Id, TotalAmount = 1000 };
            var expectedResult = new GetSaleResult { Id = sale.Id, TotalAmount = sale.TotalAmount };

            _saleRepositorySubstitute.GetByIdAsync(validCommand.Id, Arg.Any<CancellationToken>())
                .Returns(sale);

            _mapperSubstitute.Map<GetSaleResult>(sale).Returns(expectedResult);

            // Act
            var result = await _handler.Handle(validCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.TotalAmount, result.TotalAmount);
        }

        /// <summary>
        /// Tests that a ValidationException is thrown when the command is invalid.
        /// </summary>
        [Fact(DisplayName = "Should throw ValidationException when command is invalid")]
        public async Task Given_InvalidCommand_When_HandleCalled_Then_ShouldThrowValidationException()
        {
            // Arrange
            var invalidCommand = new GetSaleCommand(Guid.Empty); // Invalid ID
            var validator = new GetSaleValidator();
            var validationResult = new ValidationResult(new[] { new ValidationFailure("Id", "Id is required") });

            _saleRepositorySubstitute.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns((Sale)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(invalidCommand, CancellationToken.None));
            Assert.Contains("Sale ID is required", exception.Message);
        }

        /// <summary>
        /// Tests that a KeyNotFoundException is thrown when the sale is not found.
        /// </summary>
        [Fact(DisplayName = "Should throw KeyNotFoundException when sale is not found")]
        public async Task Given_ValidCommand_When_SaleNotFound_Then_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var validCommand = new GetSaleCommand (Guid.NewGuid());

            _saleRepositorySubstitute.GetByIdAsync(validCommand.Id, Arg.Any<CancellationToken>())
                .Returns((Sale)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(validCommand, CancellationToken.None));
            Assert.Equal($"Sale with ID {validCommand.Id} not found", exception.Message);
        }
    }
}
