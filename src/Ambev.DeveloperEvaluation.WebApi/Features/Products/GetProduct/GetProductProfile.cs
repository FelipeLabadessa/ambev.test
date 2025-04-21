using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// 
    /// </summary>
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<GetProductResult, GetProductResponse>();
        }
    }
}
