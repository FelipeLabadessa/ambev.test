using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests.TestData;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
    /// </summary>
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly DatabaseFacade _databaseFacade; // Declarado aqui!
        private readonly IDbContextTransaction _transaction; // Declarado aqui!
        private readonly CreateSaleHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
        /// Sets up the test dependencies and creates fake data generators.
        /// </summary>
        public CreateSaleHandlerTests()
        {
            // Substituir repositórios e mapeador
            _saleRepository = Substitute.For<ISaleRepository>();
            _saleProductRepository = Substitute.For<ISaleProductRepository>();
            _mapper = Substitute.For<IMapper>();

            // Substituir DbContext
            _dbContext = Substitute.For<DbContext>();

            // Substituir DatabaseFacade e configurar
            _databaseFacade = Substitute.For<DatabaseFacade>(_dbContext);
            _transaction = Substitute.For<IDbContextTransaction>();

            // Configurando o DbContext para retornar o DatabaseFacade
            _dbContext.Database.Returns(_databaseFacade);

            // Configurando o DatabaseFacade para retornar uma transação mockada
            _databaseFacade.BeginTransactionAsync(Arg.Any<CancellationToken>())
                           .Returns(_transaction);

            // Inicializar o handler
            _handler = new CreateSaleHandler(_saleRepository, _mapper, _saleProductRepository, _dbContext);
        }

        /// <summary>
        /// Tests that a valid sale creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = Guid.NewGuid(),
                TotalAmount = 500m,
                CreatedAt = DateTime.UtcNow,
                Status = SaleStatus.Active
            };

            var saleProducts = CreateSaleHandlerTestData.GenerateValidSaleProductList(10);

            var transaction = Substitute.For<IDbContextTransaction>();
            _dbContext.Database.BeginTransactionAsync(Arg.Any<CancellationToken>()).Returns(transaction);

            _mapper.Map<Sale>(command).Returns(sale);
            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            result.Should().NotBeNull();
            result.Id.Should().Be(sale.Id);
            result.TotalAmount.Should().Be(sale.TotalAmount);
            result.Products.Count.Should().Be(command.Products.Count);

            await _saleRepository.Received(1).CreateAsync(Arg.Is<Sale>(s =>
                s.TotalAmount == sale.TotalAmount &&
                s.Status == SaleStatus.Active), Arg.Any<CancellationToken>());

            await _saleProductRepository.Received(1).CreateBatchAsync(Arg.Is<List<SaleProduct>>(p =>
                p.Count == saleProducts.Count), Arg.Any<CancellationToken>());

            await transaction.Received(1).CommitAsync(Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Given valid sale data When creating sale Then commits transaction")]
        public async Task Handle_ValidRequest_CommitsTransaction()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                CustomerID = command.CustomerID,
                BranchId = command.BranchId,
                TotalAmount = 500m,
                Status = SaleStatus.Active,
                CreatedAt = DateTime.UtcNow
            };

            var saleProducts = CreateSaleHandlerTestData.GenerateValidSaleProductList(10);

            // Configurar mocks
            _mapper.Map<Sale>(command).Returns(sale);
            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);
            _saleProductRepository.CreateBatchAsync(Arg.Any<List<SaleProduct>>(), Arg.Any<CancellationToken>()).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sale.Id);

            // Verificações de chamada de métodos mockados
            await _databaseFacade.Received(1).BeginTransactionAsync(Arg.Any<CancellationToken>());
            await _transaction.Received(1).CommitAsync(Arg.Any<CancellationToken>());
            await _saleRepository.Received(1).CreateAsync(sale, Arg.Any<CancellationToken>());
            await _saleProductRepository.Received(1).CreateBatchAsync(Arg.Any<List<SaleProduct>>(), Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Tests that an invalid sale creation request throws a validation exception.
        /// </summary>
        [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = CreateSaleHandlerTestData.GenerateInvalidCommand();

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }

        /// <summary>
        /// Tests that a rollback is performed when an error occurs during the sale creation process.
        /// </summary>
        [Fact(DisplayName = "Given error during product creation When handling Then rolls back transaction")]
        public async Task Handle_ErrorDuringProductCreation_RollsBackTransaction()
        {
            // Given
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = Guid.NewGuid(),
                TotalAmount = 500m,
                CreatedAt = DateTime.UtcNow,
                Status = SaleStatus.Active
            };

            var transaction = Substitute.For<IDbContextTransaction>();
            _dbContext.Database.BeginTransactionAsync(Arg.Any<CancellationToken>()).Returns(transaction);

            _mapper.Map<Sale>(command).Returns(sale);
            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);
            _saleProductRepository.When(x =>
                x.CreateBatchAsync(Arg.Any<List<SaleProduct>>(), Arg.Any<CancellationToken>())
            ).Do(x => throw new Exception("Simulated error during product creation"));

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<ApplicationException>().WithMessage("An error occurred while processing the sale.");

            await transaction.Received(1).RollbackAsync(Arg.Any<CancellationToken>());
            await transaction.DidNotReceive().CommitAsync(Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Tests that the mapper is called with the correct command during sale creation.
        /// </summary>
        [Fact(DisplayName = "Given valid command When handling Then maps command to sale entity")]
        public async Task Handle_ValidRequest_MapsCommandToSale()
        {
            // Given
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = Guid.NewGuid(),
                TotalAmount = 500m,
                CreatedAt = DateTime.UtcNow,
                Status = SaleStatus.Active
            };

            _mapper.Map<Sale>(command).Returns(sale);
            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

            // When
            await _handler.Handle(command, CancellationToken.None);

            // Then
            _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
                c.CustomerID == command.CustomerID &&
                c.BranchId == command.BranchId &&
                c.Products.SequenceEqual(command.Products)));
        }
    }
}
