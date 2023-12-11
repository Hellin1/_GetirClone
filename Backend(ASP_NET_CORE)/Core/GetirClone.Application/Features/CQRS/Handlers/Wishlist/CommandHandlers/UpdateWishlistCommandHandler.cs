using AutoMapper;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateWishlistCommandHandler : IRequestHandler<UpdateWishlistCommand>
    {
        private readonly IUow _uow;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IMapper _mapper;

        public UpdateWishlistCommandHandler(IUow uow, IMapper mapper, IWishlistRepository wishlistRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _wishlistRepository = wishlistRepository;
        }

        public async Task<Unit> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _uow.GetRepository<Wishlist>().GetByIdAsync(request.Id, cancellationToken);
            if (updatedEntity != null)
            {
                var productWishlists = await _uow.GetRepository<ProductWishlist>().GetListByFilterAsync(pw => pw.WishlistId == request.Id, cancellationToken);
                _uow.GetRepository<ProductWishlist>().RemoveRange(productWishlists);

                updatedEntity.ProductWishlists = GetProductWishlistsFromIds(request.ProductIds, request.Id);
                updatedEntity.CustomerId = request.CustomerId;
                updatedEntity.Name = request.Name;
                _uow.GetRepository<Wishlist>().Update(updatedEntity);
                await _uow.SaveChangesAsync();
            }

            return Unit.Value;
        }

        private static List<ProductWishlist> GetProductWishlistsFromIds(List<int> ProductIds, int wishlistId)
        {
            List<ProductWishlist> productWishlists = new();

            foreach (var productId in ProductIds)
            {
                productWishlists.Add(new ProductWishlist { ProductId = productId, WishlistId = wishlistId });
            }

            return productWishlists;
        }
    }
}
