using FluentValidation;
using GetirClone.Application.Consts;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IUow _uow;
        private readonly ICartRepository _cartRepository;
        public CreateOrderCommandValidator(IUow uow, ICartRepository cartRepository)
        {
            _uow = uow;
            _cartRepository = cartRepository;

            RuleFor(cmd => cmd.CustomerId).Cascade(CascadeMode.Stop).
                NotEmpty().
                MustAsync(CartPriceGtThanMin).
                MustAsync(CartBeReadyForCreatingOrder);
        }

        private async Task<bool> CartBeReadyForCreatingOrder(Guid customerId, CancellationToken token)
        {
            var cart = await _cartRepository.GetCartWithProducts(customerId, token);
            if (cart == null) return false;
            if (cart.ProductCarts == null || !cart.ProductCarts.Any()) return false;

            var primaryAddress = await _uow.GetRepository<Address>().GetByFilterAsync(a => a.CustomerId == customerId && a.IsPrimary, token);
            if (primaryAddress == null) return false;

            var activePaymentCard = await _uow.GetRepository<PaymentCard>().GetByFilterAsync(a => a.CustomerId == customerId && a.IsPrimary, token);
            if (activePaymentCard == null) return false;

            return true;
        }


        private async Task<bool> CartPriceGtThanMin(Guid customerId, CancellationToken token)
        {
            var cart = await _cartRepository.GetCartIncludeAll(customerId, token);
            var totalPrice = _cartRepository.CalculateCartTotal(cart);
            return totalPrice >= GeneralConstants.MinimumCartPrice;
        }
    }
}
