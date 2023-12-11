using AutoMapper;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveWishlistCommandHandler : IRequestHandler<RemoveWishlistCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public RemoveWishlistCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemoveWishlistCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _uow.GetRepository<Wishlist>().GetByIdAsync(request.Id, cancellationToken);

            if (deletedEntity != null)
            {
                _uow.GetRepository<Wishlist>().Remove(deletedEntity);
                await _uow.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
