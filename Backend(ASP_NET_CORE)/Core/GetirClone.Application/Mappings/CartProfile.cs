using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartListDto>().ReverseMap();
        }
    }
}
