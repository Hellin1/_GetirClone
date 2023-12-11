using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class CreatePaymentCardCommand : IRequest<CreatedEntityDto>
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string CardNickName { get; set; }
        public string ExpiryDate { get; set; }
        public Guid CustomerId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
