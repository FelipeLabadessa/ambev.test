using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 100);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}
