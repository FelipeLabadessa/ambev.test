using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    /// <summary>
    /// Represents a customer entity.
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets the date and time when the customer was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the customer's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The sales associated with the customer.
        /// </summary>
        public ICollection<Sale>? Sales { get; set; }

    }
}