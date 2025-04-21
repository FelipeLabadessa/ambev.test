using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of the ISaleProductRepository interface for managing SaleProduct entities.
    /// Provides methods for CRUD operations and batch handling of SaleProducts in the repository. 
    /// </summary>
    public class SaleProductRepository : ISaleProductRepository
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the SaleProductRepository class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public SaleProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Creates a new SaleProduct in the repository.
        /// </summary>
        /// <param name="saleProduct">The SaleProduct to create.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>The created SaleProduct.</returns>
        public async Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default)
        {
            if (saleProduct == null)
                throw new ArgumentNullException(nameof(saleProduct));

            await _dbContext.Set<SaleProduct>().AddAsync(saleProduct, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return saleProduct;
        }

        /// <summary>
        /// Creates multiple SaleProducts in the repository in a single operation.
        /// </summary>
        /// <param name="saleProducts">The collection of SaleProducts to create.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        public async Task CreateBatchAsync(IEnumerable<SaleProduct> saleProducts, CancellationToken cancellationToken = default)
        {
            if (saleProducts == null || !saleProducts.Any())
                throw new ArgumentException("The collection of SaleProducts cannot be null or empty.", nameof(saleProducts));

            await _dbContext.Set<SaleProduct>().AddRangeAsync(saleProducts, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all SaleProducts in the repository.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>An IEnumerable of all SaleProducts.</returns>
        public async Task<IEnumerable<SaleProduct>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<SaleProduct>().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all SaleProducts associated with a specific Sale ID.
        /// </summary>
        /// <param name="saleId">The unique identifier of the Sale.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>An IEnumerable of SaleProducts associated with the Sale.</returns>
        public async Task<IEnumerable<SaleProduct>> GetAllBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<SaleProduct>()
                .Where(sp => sp.SaleId == saleId)
                .ToListAsync(cancellationToken);
        }
    }
}