using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using Ambev.DeveloperEvaluation.Domain.Validation.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    /// <summary>
    /// Represents a sale entity.
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// The unique identifier for the sale.
        /// </summary>
        public Guid SaleNumber { get; set; }

        /// <summary>
        /// The date when the sale was made.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The customer associated with the sale.
        /// </summary>
        public Customer? Customer { get; set; }

        /// <summary>
        /// The customerId associated with the sale.
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// The total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The ID of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// The products associated with the sale.
        /// </summary>
        public ICollection<SaleProduct> Products { get; set; } = new List<SaleProduct>();

        /// <summary>
        /// A mapping of product IDs to their respective quantities.
        /// </summary>
        public Dictionary<Guid, int>? AmountByItem { get; set; }

        /// <summary>
        /// The current status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the sales's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the Sale class.
        /// </summary>
        public Sale()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the sale entity using the SaleValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Calculates the total amount of the sale based on products and their quantities.
        /// </summary>
        public void CalculateTotalAmount()
        {
            if (Products == null || AmountByItem == null)
                throw new InvalidOperationException("Products and AmountByItem must be set before calculating the total amount.");

            TotalAmount = Products
                .Where(sp => AmountByItem.ContainsKey(sp.ProductId))
                .Sum(sp => sp.Product.UnitPrice * AmountByItem[sp.ProductId]);
        }

        /// <summary>
        /// Cancels the sale, changing its status to Cancelled.
        /// </summary>
        public void Cancel()
        {
            if (Status != SaleStatus.Active)
                throw new InvalidOperationException("Only active sales can be cancelled.");

            Status = SaleStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}