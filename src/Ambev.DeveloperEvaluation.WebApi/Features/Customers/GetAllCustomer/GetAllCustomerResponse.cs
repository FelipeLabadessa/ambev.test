namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer
{
    /// <summary>
    /// Represents the response model for retrieving all customer's details.
    /// </summary>
    public class GetAllCustomerResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets the date and time when the customer was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}