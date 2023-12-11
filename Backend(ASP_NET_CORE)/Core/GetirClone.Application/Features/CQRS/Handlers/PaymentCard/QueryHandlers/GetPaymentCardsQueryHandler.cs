using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetPaymentCardsQueryHandler : IRequestHandler<GetPaymentCardsQuery, List<PaymentCardListDto>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IPaymentCardRepository _paymentCardRepository;

        public GetPaymentCardsQueryHandler(IUow uow, IMapper mapper, IPaymentCardRepository paymentCardRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _paymentCardRepository = paymentCardRepository;
        }

        async Task<List<PaymentCardListDto>> IRequestHandler<GetPaymentCardsQuery, List<PaymentCardListDto>>.Handle(GetPaymentCardsQuery request, CancellationToken cancellationToken)
        {
            return await _paymentCardRepository.GetListIncludeCardType(request.CustomerId, cancellationToken);
        }
    }
}
