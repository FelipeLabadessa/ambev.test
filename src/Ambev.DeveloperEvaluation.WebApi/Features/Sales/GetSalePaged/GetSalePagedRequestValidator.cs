using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSalePaged
{
    public class GetSalePagedRequestValidator : AbstractValidator<PagedRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetProductRequest
        /// </summary>
        public GetSalePagedRequestValidator()
        {
            RuleFor(x => x.SortOrder)
                .Must(x => string.IsNullOrEmpty(x) ||
                      x.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                      x.Equals("desc", StringComparison.OrdinalIgnoreCase))
                .WithMessage("SortOrder must be 'asc', 'desc', or null.");

            RuleFor(x => x.CurrentPage)
                .GreaterThanOrEqualTo(1)
                .WithMessage("CurrentPage must be greater than or equal to 1.");

            RuleFor(x => x.ItemsPerPage)
                .GreaterThan(0)
                .WithMessage("ItemsPerPage must be greater than 0.")
                .LessThanOrEqualTo(1000)
                .WithMessage("ItemsPerPage cannot exceed 1000.");
        }
    }
}
