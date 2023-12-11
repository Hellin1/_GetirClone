using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand>
    {
        private readonly IUow _uow;
        private readonly ICartRepository _cartRepository;

        public RemoveFromCartCommandHandler(IUow uow, ICartRepository cartRepository)
        {
            _uow = uow;
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.RemoveFromCart(request.ProductId, request.CustomerId, cancellationToken);


            return Unit.Value;
        }
    }
}
