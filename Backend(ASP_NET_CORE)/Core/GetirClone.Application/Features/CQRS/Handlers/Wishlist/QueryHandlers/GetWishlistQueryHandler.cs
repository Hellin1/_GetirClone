using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetWishlistQueryHandler : IRequestHandler<GetWishlistQueryRequest, WishlistListDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IWishlistRepository _wishlistRepository;

        public GetWishlistQueryHandler(IUow uow, IMapper mapper, IWishlistRepository wishlistRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _wishlistRepository = wishlistRepository;
        }

        public async Task<WishlistListDto> Handle(GetWishlistQueryRequest request, CancellationToken cancellationToken)
        {
            var wishlist = await _wishlistRepository.GetWishlistWithProducts(request.Id, request.CustomerId, cancellationToken);

            return _mapper.Map<WishlistListDto>(wishlist);
        }
    }
}
