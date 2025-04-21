using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateProductCommand that defines validation rules for product creation command.
    /// </summary>
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Name: Required, must be between 3 and 100 characters
        /// - Amount: Must be greater than 0
        /// - UnitPrice: Must be 0 or greater
        /// </remarks>
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty().Length(3, 100);
            RuleFor(product => product.Amount).GreaterThan(0);
            RuleFor(product => product.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}