using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Sales.TestData
{
    /// <summary>
    /// Provides methods for generating test data for the Product entity using the Bogus library.
    /// </summary>
    public static class ProductTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Product entities.
        /// </summary>
        private static readonly Faker<Product> ProductFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.UnitPrice, f => f.Finance.Amount(10, 1000));

        /// <summary>
        /// Generates a list of valid Product entities.
        /// </summary>
        /// <param name="count">The number of Product entities to generate.</param>
        /// <returns>A list of valid Product entities.</returns>
        public static IEnumerable<Product> GenerateValidProducts(int count)
        {
            return ProductFaker.Generate(count);
        }

        /// <summary>
        /// Generates a list of valid SaleProduct entities based on a given list of Products.
        /// </summary>
        /// <param name="products">The list of Product entities to base the SaleProduct generation on.</param>
        /// <param name="quantity">The quantity to assign to each SaleProduct.</param>
        /// <returns>A list of valid SaleProduct entities.</returns>
        public static IEnumerable<SaleProduct> GenerateValidSaleProducts(IEnumerable<Product> products, int quantity)
        {
            return products.Select(product => new SaleProduct
            {
                SaleId = Guid.NewGuid(),
                ProductId = product.Id,
                Product = product,
                Quantity = quantity,
                TotalPrice = product.UnitPrice * quantity,
                ProductName = product.Name ?? "Default Product Name",
                CreatedAt = DateTime.UtcNow,
                DiscountTier = DiscountTier.NoDiscount
            });
        }
    }
}