using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Validator for CreateCustomerCommand that defines validation rules for customer creation command.
    /// </summary>
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the class 
        /// with validation rules for the customer creation command.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Name: Required, must be between 3 and 50 characters.
        /// </remarks>
        public CreateCustomerCommandValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty().Length(3, 50);
        }
    }
}