using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Enums.Sales;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation.Sales
{
    /// <summary>
    /// Validator for the Sale entity, enforcing business rules and data integrity.
    /// </summary>
    public class SaleValidator : AbstractValidator<Sale>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaleValidator"/> class.
        /// </summary>
        public SaleValidator()
        {
            RuleFor(s => s.SaleNumber)
                .NotEmpty().WithMessage("SaleNumber cannot be empty.");

            RuleFor(s => s.Date)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

            RuleFor(s => s.CustomerID)
                .NotEmpty().WithMessage("CustomerID cannot be empty.");

            RuleFor(s => s.TotalAmount)
                .GreaterThanOrEqualTo(0).WithMessage("TotalAmount must be greater than or equal to 0.");

            RuleFor(s => s.BranchId)
                .NotEmpty().WithMessage("BranchId cannot be empty.");

            RuleFor(s => s.Products)
                .NotNull().WithMessage("Products cannot be null.")
                .Must(products => products != null && products.Any())
                .WithMessage("At least one product must be associated with the sale.");

            RuleFor(s => s.AmountByItem)
                .NotNull().WithMessage("AmountByItem cannot be null.")
                .Must(dict => dict != null && dict.Any())
                .WithMessage("AmountByItem must not be empty.")
                .DependentRules(() =>
                {
                    RuleForEach(s => s.AmountByItem).ChildRules(items =>
                    {
                        items.RuleFor(kvp => kvp.Value)
                            .GreaterThan(0).WithMessage("Product quantities must be greater than 0.");
                    });
                });

            RuleFor(s => s.Status)
                .NotEqual(SaleStatus.Unknown).WithMessage("Sale status cannot be Unknown.");
        }
    }
}
