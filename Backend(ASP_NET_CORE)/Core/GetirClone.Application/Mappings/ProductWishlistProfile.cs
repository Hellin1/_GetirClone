using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class ProductWishlistProfile : Profile
    {
        public ProductWishlistProfile()
        {
            CreateMap<ProductWishlist, ProductWishlistListDto>().ReverseMap();
        }
    }
}
