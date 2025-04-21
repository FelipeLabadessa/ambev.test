namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    /// <summary>
    /// Result model for the UpdateCustomer operation
    /// </summary>
    public class UpdateCustomerResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? UpdatedAt { get; set; }
    }
}
