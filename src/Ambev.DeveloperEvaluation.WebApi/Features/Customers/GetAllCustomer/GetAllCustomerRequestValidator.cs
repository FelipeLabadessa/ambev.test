using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer
{
    /// <summary>
    /// Validator for GetCustomerRequest
    /// </summary>
    public class GetAllCustomerRequestValidator : AbstractValidator<GetAllCustomerRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetCustomerRequest
        /// </summary>
        public GetAllCustomerRequestValidator()
        {
      
        }
    }

}