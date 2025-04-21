using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    /// <summary>
    /// Command for updating an existing customer
    /// </summary>
    public class UpdateCustomerCommand : IRequest<UpdateCustomerResult>
    {
        /// <summary>
        /// ID of the customer to be updated
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// New name for the customer
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public UpdateCustomerCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
