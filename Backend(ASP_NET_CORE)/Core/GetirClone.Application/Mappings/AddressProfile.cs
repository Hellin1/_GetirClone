using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressListDto>().ReverseMap();
            CreateMap<Address, CreatedAddressDto>().ReverseMap();
            CreateMap<Address, ToggleIsPrimaryAddressCommand>().ReverseMap();
            CreateMap<Address, CreatedEntityDto>().ReverseMap();
        }
    }
}
