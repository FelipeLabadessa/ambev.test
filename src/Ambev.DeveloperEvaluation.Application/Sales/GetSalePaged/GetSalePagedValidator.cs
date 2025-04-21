using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged
{
    /// <summary>
    /// Validator for GetProductPagedCommand.
    /// </summary>
    public class GetSalePagedValidator : AbstractValidator<GetSalePagedCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetProductPagedCommand.
        /// </summary>
        public GetSalePagedValidator()
        {
            RuleFor(x => x.OrderBy)
               .Must(x => string.IsNullOrEmpty(x) ||
                     x.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                     x.Equals("desc", StringComparison.OrdinalIgnoreCase))
               .WithMessage("SortOrder must be 'asc', 'desc', or null.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("CurrentPage must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("ItemsPerPage must be greater than 0.")
                .LessThanOrEqualTo(1000)
                .WithMessage("ItemsPerPage cannot exceed 1000.");
        }
    }
}
