using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    /// <summary>
    /// Validator for DeleteUserCommand
    /// </summary>
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteCustomerCommand
        /// </summary>
        public DeleteCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Customer ID is required");
        }
    }
}