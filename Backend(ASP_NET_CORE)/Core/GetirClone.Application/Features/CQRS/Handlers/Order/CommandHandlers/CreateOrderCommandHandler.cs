using AutoMapper;
using FluentValidation;
using GetirClone.Application.Dto;
using GetirClone.Application.Enums;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderDto>
    {
        private readonly IUow _uow;
        private readonly ITransactionManager _transactionManager;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderCommand> _validator;

        public CreateOrderCommandHandler(IUow uow, ICartRepository cartRepository, IMapper mapper, IValidator<CreateOrderCommand> validator, ITransactionManager transactionManager)
        {
            _uow = uow;
            _cartRepository = cartRepository;
            _mapper = mapper;
            _validator = validator;
            _transactionManager = transactionManager;
        }


        async Task<CreatedOrderDto> IRequestHandler<CreateOrderCommand, CreatedOrderDto>.Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartWithProducts(request.CustomerId, cancellationToken);

            var primaryAddress = await _uow.GetRepository<Address>().GetByFilterAsync(x => x.CustomerId == request.CustomerId && x.IsPrimary, cancellationToken);

            var order = new Order
            {
                CustomerId = request.CustomerId,
                Date = DateTime.UtcNow,
                DontRingBell = request.DontRingBell,
                Note = request.Note
            };

            List<OrderItem> orderItems = new();
            foreach (var productCart in cart.ProductCarts)
            {
                orderItems.Add(new OrderItem
                {
                    Price = productCart.Product.Price,
                    ProductId = productCart.ProductId,
                    Quantity = productCart.Quantity,
                    Order = order,
                    OrderId = order.Id,
                });
            }

            order.OrderItems = orderItems;
            order.TotalPrice = cart.TotalPrice;
            order.TotalAmount = cart.TotalQuantity;

            Shipment shipment = new()
            {
                CustomerId = request.CustomerId,
                AddressId = primaryAddress.Id,
                Date = DateTime.UtcNow,
                ShipmentStateId = (int)ShipmentStateEnum.SiparisAlindi,
                TrackingNumber = Guid.NewGuid().ToString("N"),
            };

            var activePaymentCard = await _uow.GetRepository<PaymentCard>().GetByFilterAsync(x => x.IsPrimary && x.CustomerId == request.CustomerId, cancellationToken);

            Payment payment = new()
            {
                CustomerId = request.CustomerId,
                Amount = 1,
                Date = DateTime.UtcNow,
                PaymentCardId = activePaymentCard.Id,
                TotalPrice = cart.TotalPrice,
                DeliveryFee = cart.DeliveryFee,
                Order = order
            };

            order.Shipment = shipment;
            order.Payment = payment;

            await _uow.GetRepository<Payment>().CreateAsync(payment);
            var result = await _uow.GetRepository<Order>().CreateAsync(order);
            await _uow.SaveChangesAsync();


            await _cartRepository.ClearCart(request.CustomerId, cancellationToken);

            return _mapper.Map<CreatedOrderDto>(result);
        }
    }
}
