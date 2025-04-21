using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Command for creating a new customer
    /// </summary>
    public class CreateCustomerCommand : IRequest<CreateCustomerResult>
    {
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of CreateCustomerCommand.
        /// </summary>
        /// <param name="name">The name of the customer</param>
        public CreateCustomerCommand(string name)
        {
            Name = name;
        }
    }
}