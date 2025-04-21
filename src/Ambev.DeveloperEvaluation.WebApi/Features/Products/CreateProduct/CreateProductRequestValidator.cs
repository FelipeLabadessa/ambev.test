using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateProductRequest
    /// </summary>
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        /// <summary>
        /// Initializes validation rules for CreateProductRequest
        /// </summary>
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name is required");

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Amount must be zero or greater");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Unit price must be greater than zero");
        }
    }
}
