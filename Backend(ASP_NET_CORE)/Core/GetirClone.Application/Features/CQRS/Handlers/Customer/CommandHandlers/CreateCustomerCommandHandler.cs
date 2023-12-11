using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, UserDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var dto = new UserDto();

            var customer = new Customer { Name = request.Name, Email = request.Email, PhoneNumber = request.PhoneNumber };

            var cart = new Cart
            {
                Customer = customer,
            };
            await _uow.GetRepository<Cart>().CreateAsync(cart);
            cart.Customer = customer;
            customer.CartId = cart.Id;

            customer = await _uow.GetRepository<Customer>().CreateAsync(customer);
            await _uow.SaveChangesAsync();

            dto.Id = customer.Id;
            dto.Name = customer.Name;
            dto.PhoneNumber = customer.PhoneNumber;
            dto.Email = customer.Email;

            return dto;
        }
    }
}
