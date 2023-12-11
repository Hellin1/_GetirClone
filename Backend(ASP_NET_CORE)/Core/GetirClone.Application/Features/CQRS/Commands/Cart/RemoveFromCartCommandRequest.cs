using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class RemoveFromCartCommand : IRequest
    {
        public int ProductId { get; set; }

        public Guid CustomerId { get; set; }

    }
}