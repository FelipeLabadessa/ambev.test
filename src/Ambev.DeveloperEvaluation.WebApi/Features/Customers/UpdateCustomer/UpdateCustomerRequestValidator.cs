using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer
{
    /// <summary>
    /// Validator for UpdateCustomerRequest that defines validation rules for updating a customer.
    /// </summary>
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Customer ID must be provided.");
            RuleFor(x => x.Name).NotEmpty().Length(3, 50).WithMessage("Customer name must be between 3 and 50 characters.");
        }
    }
}
