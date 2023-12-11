using AutoMapper;
using GetirClone.Application.Dto;

namespace GetirClone.Application.Mappings
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserDto, RabbitMQMessageDto>();
        }
    }
}
