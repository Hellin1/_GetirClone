using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand>
    {
        private readonly IUow _uow;
        private readonly ICartRepository _cartRepository;

        public AddToCartCommandHandler(IUow uow, ICartRepository cartRepository)
        {
            _uow = uow;
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.AddToCart(request, cancellationToken);

            return Unit.Value;
        }
    }
}
