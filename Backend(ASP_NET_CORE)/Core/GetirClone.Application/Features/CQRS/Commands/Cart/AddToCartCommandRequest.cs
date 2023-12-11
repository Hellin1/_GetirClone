using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class AddToCartCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //public string? Note { get; set; }
    }
}
