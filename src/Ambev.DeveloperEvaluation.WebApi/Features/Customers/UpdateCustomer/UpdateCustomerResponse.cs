namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer
{
    /// <summary>
    /// API response model for UpdateCustomer operation
    /// </summary>
    public class UpdateCustomerResponse
    {
        /// <summary>
        /// The ID of the updated customer
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The updated name of the customer
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
