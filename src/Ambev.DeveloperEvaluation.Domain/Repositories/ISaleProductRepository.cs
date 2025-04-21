using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for SaleProduct entity operations.
    /// </summary>
    public interface ISaleProductRepository
    {
        /// <summary>
        /// Creates a new SaleProduct in the repository.
        /// </summary>
        /// <param name="saleProduct">The SaleProduct to create.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>The created SaleProduct.</returns>
        Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates multiple SaleProducts in the repository in a single operation.
        /// </summary>
        /// <param name="saleProducts">The collection of SaleProducts to create.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task CreateBatchAsync(IEnumerable<SaleProduct> saleProducts, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all SaleProducts associated with a specific Sale ID.
        /// </summary>
        /// <param name="saleId">The unique identifier of the Sale.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>An IEnumerable of SaleProducts associated with the Sale.</returns>
        Task<IEnumerable<SaleProduct>> GetAllBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all SaleProducts in the repository.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>An IEnumerable of all SaleProducts.</returns>
        Task<IEnumerable<SaleProduct>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}