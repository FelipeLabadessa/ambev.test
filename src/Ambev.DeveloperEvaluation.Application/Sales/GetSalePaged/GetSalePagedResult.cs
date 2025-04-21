using Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged
{
    public class GetSalePagedResult
    {
        public GetSalePagedResult(GetSalePagedCommand paginationParameters, int totalItems, List<SaleResponse> data)
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
        public List<SaleResponse> Data { get; set; }
    }
}
