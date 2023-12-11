using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetPaymentCardQueryHandler : IRequestHandler<GetPaymentCardQuery, PaymentCardListDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IPaymentCardRepository _paymentCardRepository;

        public GetPaymentCardQueryHandler(IUow uow, IMapper mapper, IPaymentCardRepository paymentCardRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _paymentCardRepository = paymentCardRepository;
        }

        public async Task<PaymentCardListDto> Handle(GetPaymentCardQuery request, CancellationToken cancellationToken)
        {
            return await _paymentCardRepository.GetIncludeCardType(request.CustomerId, cancellationToken);
        }
    }
}
