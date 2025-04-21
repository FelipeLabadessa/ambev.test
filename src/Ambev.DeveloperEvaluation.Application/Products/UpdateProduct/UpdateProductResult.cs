namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
