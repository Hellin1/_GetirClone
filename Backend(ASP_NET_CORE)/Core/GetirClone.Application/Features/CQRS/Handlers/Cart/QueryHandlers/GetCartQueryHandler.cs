using AutoMapper;
using GetirClone.Application.Consts;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartListDto>
    {
        private readonly IUow _uow;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartQueryHandler(IUow uow, IMapper mapper, ICartRepository cartRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<CartListDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartIncludeAll(request.CustomerId, cancellationToken);
            if (cart != null)
            {
                cart.TotalPrice = _cartRepository.CalculateCartTotal(cart);

                var dto = _mapper.Map<CartListDto>(cart);

                dto.BagPrice = GeneralConstants.DefaultBagFee;
                dto.DeliveryFee = cart.TotalPrice >= GeneralConstants.MinimumPriceForFreeDelivery ? 0 : GeneralConstants.DefaultDeliveryFee;
                dto.NeededPriceForFreeDelivery = cart.TotalPrice >= GeneralConstants.MinimumPriceForFreeDelivery ? 0 :
                    GeneralConstants.MinimumPriceForFreeDelivery - cart.TotalPrice;

                return dto;
            }
            throw new SecurityTokenException("Lütfen Giriş Yapınız");
        }
    }
}
