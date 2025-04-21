namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    /// <summary>
    ///  Represents a request to create a new customer in the system.
    /// </summary>
    public class CreateCustomerRequest
    {
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
