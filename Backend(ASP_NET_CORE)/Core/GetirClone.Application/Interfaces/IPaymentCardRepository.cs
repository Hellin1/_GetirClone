using GetirClone.Application.Dto;

namespace GetirClone.Application.Interfaces
{
    public interface IPaymentCardRepository
    {
        Task<PaymentCardListDto> GetIncludeCardType(Guid customerId, CancellationToken cancellationToken);

        Task<List<PaymentCardListDto>> GetListIncludeCardType(Guid customerId, CancellationToken cancellationToken);

        Task ChangePaymentCard(int cardId, Guid customerId, CancellationToken cancellationToken);
    }
}
