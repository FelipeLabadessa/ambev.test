using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleApplicationTests.TestData
{
    /// <summary>
    /// Provides test data for DeleteSaleCommand.
    /// </summary>
    public static class DeleteSaleTestData
    {
        /// <summary>
        /// Generates a valid DeleteSaleCommand.
        /// </summary>
        /// <returns>A valid DeleteSaleCommand.</returns>
        public static DeleteSaleCommand GenerateValidCommand()
        {
            return new DeleteSaleCommand(Guid.NewGuid());
        }

        /// <summary>
        /// Generates an invalid DeleteSaleCommand with missing ID.
        /// </summary>
        /// <returns>An invalid DeleteSaleCommand.</returns>
        public static DeleteSaleCommand GenerateInvalidCommand()
        {
            return new DeleteSaleCommand(Guid.Empty);
        }
    }
}
