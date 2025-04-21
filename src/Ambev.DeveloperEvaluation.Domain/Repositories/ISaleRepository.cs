using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Sale entity operations
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a sale from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all sales associated with a specific customer ID from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the customer whose sales are to be retrieved.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an IEnumerable of <see cref="Sale"/> objects associated with the specified customer.</returns>
        Task<IEnumerable<Sale>> GetAllByCustomerId(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Sale>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);

        Task<int> GetTotalRecordsAsync();
    }
}