using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class ProductCartForProductProfile : Profile
    {
        public ProductCartForProductProfile()
        {
            CreateMap<ProductCart, ProductCartForProductDto>().ReverseMap();
        }
    }
}
