namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Result model for the CreateProduct operation
    /// </summary>
    public class CreateProductResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the created product.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the created product.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}