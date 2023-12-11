using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemListDto>().ReverseMap();
        }
    }
}
