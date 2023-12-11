using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        private readonly IUow _uow;
        private readonly ICartRepository _cartRepository;
        public AddToCartCommandValidator(ICartRepository carRepository, IUow uow)
        {
            _cartRepository = carRepository;
            _uow = uow;

            RuleFor(cmd => cmd.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
            RuleFor(cmd => cmd.ProductId).NotEmpty();

            RuleFor(cmd => cmd.ProductId).MustAsync(BeOnDatabase<Product>);
            RuleFor(cmd => cmd.CustomerId).MustAsync(CustomerMustBeOnDatabase<Customer>);
            RuleFor(cmd => cmd.CustomerId).Cascade(CascadeMode.Stop).MustAsync(CardNotNull);
        }

        private async Task<bool> CardNotNull(Guid customerId, CancellationToken token)
        {
            var cart = await _uow.GetRepository<Cart>().GetByFilterAsync(c => c.CustomerId == customerId, token);
            if (cart == null) return false;

            return true;
        }
        private async Task<bool> CustomerMustBeOnDatabase<T>(Guid id, CancellationToken token) where T : class, new()
        {
            var isExist = await _uow.GetRepository<T>().GetByIdAsync(id, token);
            if (isExist == null) return false;

            return true;
        }


        private async Task<bool> BeOnDatabase<T>(int id, CancellationToken token) where T : class, new()
        {
            var isExist = await _uow.GetRepository<T>().GetByIdAsync(id, token);
            if (isExist == null) return false;

            return true;
        }


    }
}
