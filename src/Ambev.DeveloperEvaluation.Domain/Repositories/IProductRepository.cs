using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Product entity operations
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product</returns>
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing product in the repository
        /// </summary>
        /// <param name="product">The product to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated product</returns>
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a product from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the product was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of products from the data source asynchronously.
        /// </summary>
        /// <param name="page">The page number to retrieve, starting from 1.</param>
        /// <param name="pageSize">The number of products to retrieve per page.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a collection of products for the specified page.
        /// </returns>
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the total number of products available in the database.
        /// </summary>
        /// <returns>
        /// An asynchronous task that returns the total count of products as an integer.
        /// </returns>
        Task<int> GetTotalRecordsAsync();
    }
}