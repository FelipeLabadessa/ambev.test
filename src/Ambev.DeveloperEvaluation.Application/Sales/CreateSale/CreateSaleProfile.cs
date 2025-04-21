using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Profile for mapping between Sale entity and CreateSale operations.
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSale operation.
        /// </summary>
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>().ForMember(dest => dest.Products, opt => opt.Ignore());
            CreateMap<Sale, CreateSaleResult>();
            CreateMap<SaleProductCommand, SaleProduct>();
        }
    }
}