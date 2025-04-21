using Ambev.DeveloperEvaluation.Domain.Enums.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged.DTOs
{
    public class SaleResponse
    {
        public Guid Id { get; set; }
        public Guid SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public SaleStatus Status { get; set; }
        public Guid CustomerID { get; set; }
        public Guid BranchId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<SaleProductResponse> Products { get; set; } = new();

        public class SaleProductResponse
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal TotalPrice { get; set; }
            public DiscountTier DiscountTier { get; set; }
        }
    }
}
