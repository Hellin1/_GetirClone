using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class RemoveWishlistCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveWishlistCommand(int id)
        {
            Id = id;
        }
    }
}
