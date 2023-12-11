using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class CreateWishlistCommand : IRequest<CreatedWishlistDto>
    {
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
    }
}
