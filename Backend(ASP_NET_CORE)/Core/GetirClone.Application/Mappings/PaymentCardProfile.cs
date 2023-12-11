using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class PaymentCardProfile : Profile
    {
        public PaymentCardProfile()
        {
            CreateMap<PaymentCard, PaymentCardListDto>().ReverseMap();
            CreateMap<PaymentCard, CreatedPaymentCardDto>().ReverseMap();
            CreateMap<PaymentCard, CreatedEntityDto>().ReverseMap();
        }
    }
}
