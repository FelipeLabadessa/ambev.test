namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer
{
    /// <summary>
    /// Request model for getting all customer
    /// </summary>
    public class GetAllCustomerRequest
    {
        /// <summary>
        /// The unique identifier of the customer to retrieve
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets the date and time of the last update to the customer's information.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}