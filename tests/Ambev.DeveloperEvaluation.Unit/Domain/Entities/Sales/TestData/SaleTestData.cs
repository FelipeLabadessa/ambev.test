using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Sales.TestData
{
    /// <summary>
    /// Provides methods for generating test data for the Sale entity using the Bogus library.
    /// This class centralizes test data generation to ensure consistency across test cases.
    /// </summary>
    public static class SaleTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Sale entities.
        /// </summary>
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .RuleFor(s => s.SaleNumber, f => Guid.NewGuid())
            .RuleFor(s => s.Date, f => f.Date.Recent())
            .RuleFor(s => s.CustomerID, f => Guid.NewGuid())
            .RuleFor(s => s.TotalAmount, f => f.Finance.Amount(50, 5000))
            .RuleFor(s => s.BranchId, f => Guid.NewGuid())
             .RuleFor(s => s.Products, f =>
             {
                 var products = ProductTestData.GenerateValidProducts(f.Random.Number(1, 5));
                 return products.Select(p => new SaleProduct
                 {
                     SaleId = Guid.NewGuid(),
                     ProductId = p.Id,
                     Product = p,
                     Quantity = f.Random.Number(1, 10),
                     TotalPrice = p.UnitPrice * f.Random.Number(1, 10)
                 }).ToList();
             })
            .RuleFor(s => s.AmountByItem, (f, s) =>
            {
                return s.Products.ToDictionary(
                    sp => sp.ProductId,
                    sp => sp.Quantity
                );
            })
            .RuleFor(s => s.Status, f => f.PickRandom<SaleStatus>());

        /// <summary>
        /// Generates a valid Sale entity with randomized data.
        /// </summary>
        /// <returns>A valid Sale entity.</returns>
        public static Sale GenerateValidSale()
        {
            return SaleFaker.Generate();
        }

        /// <summary>
        /// Generates a list of valid Sale entities.
        /// </summary>
        /// <param name="count">The number of Sale entities to generate.</param>
        /// <returns>A list of valid Sale entities.</returns>
        public static IEnumerable<Sale> GenerateValidSales(int count)
        {
            return SaleFaker.Generate(count);
        }

        /// <summary>
        /// Generates a Sale entity with an invalid total amount (negative value).
        /// Useful for testing validation errors.
        /// </summary>
        /// <returns>A Sale entity with an invalid total amount.</returns>
        public static Sale GenerateSaleWithInvalidTotalAmount()
        {
            var sale = GenerateValidSale();
            sale.TotalAmount = -100; // Invalid value
            return sale;
        }

        /// <summary>
        /// Generates a Sale entity with an empty product list.
        /// Useful for testing edge cases where no products are involved in the sale.
        /// </summary>
        /// <returns>A Sale entity with no products.</returns>
        public static Sale GenerateSaleWithNoProducts()
        {
            var sale = GenerateValidSale();
            sale.Products = new List<SaleProduct>(); // Lista vazia de SaleProduct
            sale.AmountByItem = new Dictionary<Guid, int>();
            return sale;
        }
    }
}