using Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Pagination;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSalePaged
{
    /// <summary>
    /// Defines the mapping profiles for paged product retrieval operations.
    /// </summary>
    public class GetSalePagedProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the class
        /// and defines mappings between data transfer objects, commands, and response models.
        /// </summary>
        public GetSalePagedProfile()
        {
            CreateMap<PaginationRequestDTO, GetSalePagedCommand>();

            CreateMap<Sale, SaleResponse>();

            CreateMap<SaleProduct, SaleResponse.SaleProductResponse>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.DiscountTier, opt => opt.MapFrom(src => src.DiscountTier));
        }
    }
}
