namespace Ambev.DeveloperEvaluation.Domain.Enums.Sales
{
    /// <summary>
    /// Represents the tiers of discounts based on sales volume.
    /// </summary>
    public enum DiscountTier
    {
        /// <summary>
        /// No discount is applied.
        /// </summary>
        NoDiscount = 0,

        /// <summary>
        /// A 10% discount is applied.
        /// </summary>
        TenPercent = 10,

        /// <summary>
        /// A 20% discount is applied.
        /// </summary>
        TwentyPercent = 20
    }
}