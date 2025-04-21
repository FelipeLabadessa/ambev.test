namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer
{
    /// <summary>
    /// Represents a request to update an existing customer in the system.
    /// </summary>
    public class UpdateCustomerRequest
    {
        /// <summary>
        /// The ID of the customer to update.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The new name for the customer.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
