using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    /// <summary>
    /// Validator for UpdateCustomerCommand
    /// </summary>
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Customer ID must be provided.");
            RuleFor(x => x.Name).NotEmpty().Length(3, 50).WithMessage("Customer name must be between 3 and 50 characters.");
        }
    }
}
