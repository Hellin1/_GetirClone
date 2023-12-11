using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class WishlistProfile : Profile
    {
        public WishlistProfile()
        {
            CreateMap<Wishlist, WishlistListDto>().ReverseMap();
            CreateMap<Wishlist, CreatedWishlistDto>().ReverseMap();

        }
    }
}
