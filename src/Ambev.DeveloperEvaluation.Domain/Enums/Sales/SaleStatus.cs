using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Enums.Sales
{
    /// <summary>
    /// Represents the status of a sale.
    /// </summary>
    public enum SaleStatus
    {
        /// <summary>
        /// Invalid sale satus.
        /// </summary>
        [Display(Name = "Unknown")]
        Unknown = 0,
        
        /// <summary>
        /// The sale is active and valid.
        /// </summary>
        [Display(Name = "Active")]
        Active = 1,

        /// <summary>
        /// The sale has been canceled.
        /// </summary>
        [Display(Name = "Canceled")]
        Cancelled = 2,
    }
}