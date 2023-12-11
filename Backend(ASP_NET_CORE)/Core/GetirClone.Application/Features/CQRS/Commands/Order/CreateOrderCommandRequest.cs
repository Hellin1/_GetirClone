using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class CreateOrderCommand : IRequest<CreatedOrderDto>
    {
        public Guid CustomerId { get; set; }
        public bool DontRingBell { get; set; }
        public string? Note { get; set; }
    }
}
