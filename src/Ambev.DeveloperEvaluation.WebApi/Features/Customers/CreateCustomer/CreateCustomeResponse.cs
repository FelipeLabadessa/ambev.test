namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    /// <summary>
    /// API response model for CreateCustomer operation
    /// </summary>
    public class CreateCustomerResponse
    {
        /// <summary>
        /// The unique identifier of the created customer
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The customer's full name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
