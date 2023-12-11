using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands.Cart
{
    public class EmptyCartCommand : IRequest
    {
        public Guid CustomerId { get; set; }
    }
}
