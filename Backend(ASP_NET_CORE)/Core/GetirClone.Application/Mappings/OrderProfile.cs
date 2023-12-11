using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreatedOrderDto>().ReverseMap();
            CreateMap<Order, OrderListDto>().ReverseMap();
            CreateMap<Order, OrderWithoutNavPropsListDto>().ReverseMap();
            //CreateMap<OrderListDto, OrderWithoutNavPropsListDto>().ReverseMap();
        }
    }
}
