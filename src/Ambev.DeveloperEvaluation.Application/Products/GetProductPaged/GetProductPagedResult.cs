using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductPaged
{
    public class GetProductPagedResult
    {
        public GetProductPagedResult(GetProductPagedCommand paginationParameters, int totalItems, List<Product> data)
        {
            ActualPage = paginationParameters.PageNumber;
            TotalItems = totalItems;
            TotalPages = totalItems / paginationParameters.PageSize;
            if (totalItems % paginationParameters.PageSize > 0)
            {
                TotalPages++;
            }
            Data = data;
        }

        public int ActualPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<Product> Data { get; set; }
    }
}