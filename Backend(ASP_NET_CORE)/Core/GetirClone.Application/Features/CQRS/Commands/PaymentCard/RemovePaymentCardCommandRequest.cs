using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class RemovePaymentCardCommand : IRequest
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public RemovePaymentCardCommand(int id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
