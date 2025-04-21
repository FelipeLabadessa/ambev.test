namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer
{
    /// <summary>
    /// Represents the response model for retrieving a customer's details.
    /// </summary>
    public class GetCustomerResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
