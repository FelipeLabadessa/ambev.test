using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests.TestData;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests
{
    /// <summary>
    /// Contains unit tests for the DeleteSaleCommand handler.
    /// </summary>
    public class DeleteSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepositorySubstitute;
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _saleRepositorySubstitute = Substitute.For<ISaleRepository>();
            _handler = new DeleteSaleHandler(_saleRepositorySubstitute);
        }

        /// <summary>
        /// Tests that a sale is successfully deleted when a valid request is provided.
        /// </summary>
        [Fact(DisplayName = "Should successfully delete a sale when valid request is provided")]
        public async Task Given_ValidRequest_When_HandleCalled_Then_ShouldDeleteSaleSuccessfully()
        {
            // Arrange
            var validCommand = DeleteSaleTestData.GenerateValidCommand();
            _saleRepositorySubstitute.DeleteAsync(validCommand.Id, Arg.Any<CancellationToken>()).Returns(true);

            // Act
            var result = await _handler.Handle(validCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            await _saleRepositorySubstitute.Received(1).DeleteAsync(validCommand.Id, Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Tests that a ValidationException is thrown when an invalid request is provided.
        /// </summary>
        [Fact(DisplayName = "Should throw ValidationException when request is invalid")]
        public async Task Given_InvalidRequest_When_HandleCalled_Then_ShouldThrowValidationException()
        {
            // Arrange
            var invalidCommand = DeleteSaleTestData.GenerateInvalidCommand();
            var validatorSubstitute = Substitute.For<IValidator<DeleteSaleCommand>>();
            validatorSubstitute.ValidateAsync(invalidCommand, Arg.Any<CancellationToken>())
                .Returns(new ValidationResult(new[] { new ValidationFailure("Id", "Id is required") }));

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(invalidCommand, CancellationToken.None));
            await _saleRepositorySubstitute.DidNotReceive().DeleteAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Tests that a KeyNotFoundException is thrown when a sale does not exist.
        /// </summary>
        [Fact(DisplayName = "Should throw KeyNotFoundException when sale does not exist")]
        public async Task Given_ValidRequest_When_SaleDoesNotExist_Then_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var validCommand = DeleteSaleTestData.GenerateValidCommand();
            _saleRepositorySubstitute.DeleteAsync(validCommand.Id, Arg.Any<CancellationToken>()).Returns(false);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(validCommand, CancellationToken.None));
            await _saleRepositorySubstitute.Received(1).DeleteAsync(validCommand.Id, Arg.Any<CancellationToken>());
        }
    }
}
