using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveProductFromWishlistCommandHandler : IRequestHandler<RemoveProductFromWishlistCommand>
    {
        private readonly IUow _uow;
        private readonly IWishlistRepository _wishlistRepository;

        public RemoveProductFromWishlistCommandHandler(IUow uow, IWishlistRepository wishlistRepository)
        {
            _uow = uow;
            _wishlistRepository = wishlistRepository;
        }

        public async Task<Unit> Handle(RemoveProductFromWishlistCommand request, CancellationToken cancellationToken)
        {
            var removedEntity = await _uow.GetRepository<ProductWishlist>().GetByFilterAsync(pw => pw.WishlistId == request.WishlistId && pw.ProductId == request.ProductId, cancellationToken);

            if (removedEntity != null)
            {
                _uow.GetRepository<ProductWishlist>().Remove(removedEntity);
                await _uow.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
