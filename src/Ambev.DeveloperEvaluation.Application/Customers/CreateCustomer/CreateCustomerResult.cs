namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Result model for the CreateCustomer operation
    /// </summary>
    public class CreateCustomerResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the created customer.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the created customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the date and time when the customer was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}