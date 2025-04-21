using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer
{
    /// <summary>
    /// Validator for GetAllCustomerCommand
    /// </summary>
    public class GetAllCustomerValidator : AbstractValidator<GetAllCustomerCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetAllCustomerCommand
        /// </summary>
        public GetAllCustomerValidator()
        {
            //RuleFor(x => x.Id)
            //    .NotEmpty()
            //    .WithMessage("Customer ID is required");
        }
    }
}