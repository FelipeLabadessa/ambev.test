using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    // <summary>
    /// Validator for CreateSaleRequest that defines validation rules for sale creation.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleRequestValidator class with validation rules.
        /// </summary>
        public CreateSaleRequestValidator()
        {
            RuleFor(request => request.CustomerID)
                .NotEmpty()
                .WithMessage("CustomerID is required.");

            RuleFor(request => request.BranchId)
                .NotEmpty()
                .WithMessage("BranchId is required.");

            RuleFor(request => request.Products)
                .NotEmpty()
                .WithMessage("At least one product is required in the sale.")
                .ForEach(product =>
                {
                    // Nested validator for SaleProductRequest
                    product.SetValidator(new SaleProductRequestValidator());
                });
        }
    }

    /// <summary>
    /// Validator for SaleProductRequest that defines validation rules for products in a sale.
    /// </summary>
    public class SaleProductRequestValidator : AbstractValidator<SaleProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the SaleProductRequestValidator class with validation rules.
        /// </summary>
        public SaleProductRequestValidator()
        {
            RuleFor(product => product.Id)
                .NotEmpty()
                .WithMessage("Product id is required.");

            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Product name is required.");

            RuleFor(product => product.Amount)
                .GreaterThan(0)
                .WithMessage("Product amount must be greater than zero.")
                .LessThanOrEqualTo(20)
                .WithMessage("Product amount must not exceed 20.");
        }
    }
}