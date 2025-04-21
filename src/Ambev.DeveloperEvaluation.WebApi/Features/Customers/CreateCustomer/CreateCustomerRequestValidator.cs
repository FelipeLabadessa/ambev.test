using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    /// <summary>
    /// Validator for CreateCustomerRequest that defines validation rules for customer creation.
    /// </summary>
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        /// <summary>
        /// Initializes validation rules for CreateCustomerCommand
        /// </summary>
        public CreateCustomerRequestValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty().Length(3, 50);
        }
    }
}