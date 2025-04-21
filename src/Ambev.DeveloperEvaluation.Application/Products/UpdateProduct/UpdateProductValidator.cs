using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 100);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}
