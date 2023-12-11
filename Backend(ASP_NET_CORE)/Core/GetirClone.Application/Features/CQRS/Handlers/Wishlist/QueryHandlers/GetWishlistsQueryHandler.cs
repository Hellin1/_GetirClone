using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetWishlistsQueryHandler : IRequestHandler<GetWishlistsQueryRequest, List<WishlistListDto>>
    {
        private readonly IUow _uow;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IMapper _mapper;
        private readonly IMessageProducer _messageProducer;

        public GetWishlistsQueryHandler(IUow uow, IMapper mapper, IWishlistRepository wishlistRepository, IMessageProducer messageProducer)
        {
            _uow = uow;
            _mapper = mapper;
            _wishlistRepository = wishlistRepository;
            _messageProducer = messageProducer;
        }

        public async Task<List<WishlistListDto>> Handle(GetWishlistsQueryRequest request, CancellationToken cancellationToken)
        {
            var lists = await _wishlistRepository.GetWishlistsWithProducts(request.CustomerId, cancellationToken);

            var listsWithoutNavProps = lists.Select(p => new WishlistListDto
            {
                Id = p.Id,
                Name = p.Name,

            });

            return _mapper.Map<List<WishlistListDto>>(lists);
        }
    }
}
