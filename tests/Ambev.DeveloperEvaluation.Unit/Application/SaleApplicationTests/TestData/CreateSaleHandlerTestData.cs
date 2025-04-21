using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests.TestData
{
    /// <summary>
    /// Provides test data for CreateSaleHandler unit tests.
    /// </summary>
    public static class CreateSaleHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid CreateSaleCommand objects.
        /// </summary>
        private static readonly Faker<CreateSaleCommand> createSaleCommandFaker = new Faker<CreateSaleCommand>()
            .RuleFor(c => c.CustomerID, f => Guid.NewGuid())
            .RuleFor(c => c.BranchId, f => Guid.NewGuid())
            .RuleFor(c => c.Products, f => GenerateValidProducts(10));

        /// <summary>
        /// Generates a valid CreateSaleCommand.
        /// </summary>
        /// <returns>A valid CreateSaleCommand instance.</returns>
        public static CreateSaleCommand GenerateValidCommand()
        {
            return createSaleCommandFaker.Generate();
        }

        /// <summary>
        /// Generates a valid list of products for a sale.
        /// </summary>
        /// <returns>A valid list of products.</returns>
        private static List<SaleProductCommand> GenerateValidProducts(int amount)
        {
            return new Faker<SaleProductCommand>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Amount, f => f.Random.Int(1, 20))
                .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 100))
                .Generate(amount);
        }

        /// <summary>
        /// Generates an invalid CreateSaleCommand (e.g., missing CustomerID or invalid products).
        /// </summary>
        /// <returns>An invalid CreateSaleCommand instance.</returns>
        public static CreateSaleCommand GenerateInvalidCommand()
        {
            return new CreateSaleCommand
            {
                CustomerID = Guid.Empty,
                BranchId = Guid.Empty,
                Products = new List<SaleProductCommand>()
            };
        }

        /// <summary>
        /// Generates a valid list of <see cref="SaleProduct"/> entities.
        /// </summary>
        /// <returns>A list of valid <see cref="SaleProduct"/> entities for the test.</returns>
        public static List<SaleProduct> GenerateValidSaleProductList(int amount)
        {
            return new Faker<SaleProduct>()
                .RuleFor(p => p.ProductId, f => Guid.NewGuid())
                .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
                .RuleFor(p => p.Quantity, f => f.Random.Int(1, 20))
                .RuleFor(p => p.DiscountTier, f => f.PickRandom<DiscountTier>())
                //.RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 100)) // Random price
                //.RuleFor(p => p.TotalPrice, (f, p) => p.Quantity * p.UnitPrice) // Calculate total price
                .Generate(amount);
        }
    }
}
