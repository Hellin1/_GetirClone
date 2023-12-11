using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Interfaces;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GetirClone.Persistance.Repositories
{
    public class PaymentCardRepository : IPaymentCardRepository
    {
        private readonly GetirCloneContext _context;
        private readonly IMapper _mapper;

        public PaymentCardRepository(GetirCloneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentCardListDto> GetIncludeCardType(Guid customerId, CancellationToken cancellationToken)
        {
            var paymentCards = await _context.PaymentCards.Where(pc => pc.CustomerId == customerId && pc.IsPrimary && !pc.IsPassive).Include(pc => pc.CardType).Select(pc => new PaymentCardListDto
            {
                CardNumber = pc.CardNumber,
                CardHolderName = pc.CardHolderName,
                ExpiryDate = pc.ExpiryDate,
                IsPrimary = pc.IsPrimary,
                CardType = pc.CardType,
            }).FirstOrDefaultAsync(cancellationToken);

            return paymentCards;
        }

        public async Task<List<PaymentCardListDto>> GetListIncludeCardType(Guid customerId, CancellationToken cancellationToken)
        {
            var paymentCards = await _context.PaymentCards.Where(pc => pc.CustomerId == customerId && !pc.IsPassive).Include(pc => pc.CardType).ToListAsync(cancellationToken);
            var dto = _mapper.Map<List<PaymentCardListDto>>(paymentCards);

            return dto;
        }

        public async Task ChangePaymentCard(int cardId, Guid customerId, CancellationToken cancellationToken)
        {
            var activePaymetCard = await _context.PaymentCards.SingleOrDefaultAsync(pc => pc.CustomerId == customerId && pc.IsPrimary, cancellationToken);

            if (activePaymetCard != null)
            {
                activePaymetCard.IsPrimary = false;
            }

            var paymentCard = await _context.PaymentCards.SingleOrDefaultAsync(pc => pc.Id == cardId, cancellationToken);
            if (paymentCard != null)
            {
                paymentCard.IsPrimary = true;
            }
        }

        public async Task RemovePaymentCard(int cardId, CancellationToken cancellationToken)
        {
            var paymentCard = await _context.PaymentCards.SingleOrDefaultAsync(pc => pc.Id == cardId);
            if (paymentCard != null)
            {
                if (paymentCard.IsPrimary)
                {
                    var randomCa = await _context.PaymentCards.OrderByDescending(pc => pc.LastPrimaryDate).FirstOrDefaultAsync(pc => pc.Id != cardId);
                    if (randomCa != null)
                    {
                        randomCa.IsPrimary = true;
                    }
                }

                paymentCard.IsPassive = true;
                paymentCard.IsPrimary = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
