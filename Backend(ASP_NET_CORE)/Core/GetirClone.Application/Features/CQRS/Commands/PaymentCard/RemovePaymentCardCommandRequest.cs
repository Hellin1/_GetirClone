using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class RemovePaymentCardCommand : IRequest
    {
        public int Id { get; set; }

        public RemovePaymentCardCommand(int id)
        {
            Id = id;
        }

        public Guid? CustomerId { get; set; }

    }
}
