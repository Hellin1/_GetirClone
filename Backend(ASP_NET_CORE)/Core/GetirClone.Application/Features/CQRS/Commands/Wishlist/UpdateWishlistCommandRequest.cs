using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class UpdateWishlistCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
