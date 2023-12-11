using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class RemoveAddressCommand : IRequest
    {
        public RemoveAddressCommand(int id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
