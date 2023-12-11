using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class ToggleIsPrimaryAddressCommand : IRequest
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}