using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUserPaged
{
    public class GetUserPagedResult
    {
        public GetUserPagedResult(GetUserPagedCommand paginationParameters, int totalItems, List<User> data)
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
        public List<User> Data { get; set; }
    }
}
