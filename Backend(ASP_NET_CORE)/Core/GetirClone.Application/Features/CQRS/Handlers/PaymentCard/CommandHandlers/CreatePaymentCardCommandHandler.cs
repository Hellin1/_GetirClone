using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;
using System.Text.RegularExpressions;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreatePaymentCardCommandHandler : IRequestHandler<CreatePaymentCardCommand, CreatedEntityDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public CreatePaymentCardCommandHandler(IUow uow, IMapper mapper, ICacheService cacheService)
        {
            _uow = uow;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<CreatedEntityDto> Handle(CreatePaymentCardCommand request, CancellationToken cancellationToken)
        {
            var primaryCard = await _uow.GetRepository<PaymentCard>().GetByFilterAsync(pc => pc.CustomerId == request.CustomerId && pc.IsPrimary, cancellationToken);

            var oldCard = await _uow.GetRepository<PaymentCard>().GetByFilterAsync(pc => pc.CardNumber == request.CardNumber, cancellationToken);

            if (primaryCard != null)
                primaryCard.IsPrimary = false;

            if (oldCard != null)
            {
                oldCard.IsPassive = false;
                oldCard.IsPrimary = true;
                await _uow.SaveChangesAsync();
                return _mapper.Map<CreatedEntityDto>(oldCard);
            }

            var paymentCard = new PaymentCard
            {
                CardNumber = request.CardNumber,
                CardHolderName = request.CardHolderName,
                CardNickName = request.CardNickName,
                ExpiryDate = request.ExpiryDate,
                CustomerId = request.CustomerId,
                PaymentMethodId = request.PaymentMethodId,
                IsPrimary = true
            };

            paymentCard.CardTypeId = await DetectCardType(paymentCard.CardNumber, cancellationToken);

            var result = await _uow.GetRepository<PaymentCard>().CreateAsync(paymentCard);
            await _uow.SaveChangesAsync();

            return _mapper.Map<CreatedEntityDto>(result);
        }

        private async Task<int> DetectCardType(string cardNumber, CancellationToken cancellationToken)
        {
            var cardTypes = await _cacheService.GetOrSetList<CardType>(nameof(CardType));

            foreach (var cardType in cardTypes)
            {
                if (Regex.IsMatch(cardNumber, cardType.RegexPattern))
                {
                    return cardType.Id;
                }
            }

            return 0;
        }
    }
}