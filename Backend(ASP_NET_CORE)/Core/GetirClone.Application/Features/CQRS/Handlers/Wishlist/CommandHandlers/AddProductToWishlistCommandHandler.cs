using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class AddProductToWishlistCommandHandler : IRequestHandler<AddProductToWishlistCommand>
    {
        private readonly IUow _uow;
        private readonly IWishlistRepository _wishlistRepository;

        public AddProductToWishlistCommandHandler(IUow uow, IWishlistRepository wishlistRepository)
        {
            _uow = uow;
            _wishlistRepository = wishlistRepository;
        }

        public async Task<Unit> Handle(AddProductToWishlistCommand request, CancellationToken cancellationToken)
        {
            var wishlist = await _wishlistRepository.GetWishlistWithProducts(request.WishlistId, request.CustomerId, cancellationToken);

            wishlist?.ProductWishlists.AddRange(new List<ProductWishlist>
            {
                new ProductWishlist
                {
                    ProductId = request.ProductId,
                    WishlistId = request.WishlistId
                }
            });


            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
