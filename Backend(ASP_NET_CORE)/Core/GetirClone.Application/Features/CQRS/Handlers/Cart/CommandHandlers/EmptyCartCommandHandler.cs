using GetirClone.Application.Features.CQRS.Commands.Cart;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class EmptyCartCommandHandler : IRequestHandler<EmptyCartCommand>
    {
        private readonly IUow _uow;
        private readonly ICartRepository _cartRepository;

        public EmptyCartCommandHandler(IUow uow, ICartRepository cartRepository)
        {
            _uow = uow;
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(EmptyCartCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.ClearCart(request.CustomerId, cancellationToken);

            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
