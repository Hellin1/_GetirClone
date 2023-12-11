using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommand, CreatedWishlistDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateWishlistCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        async Task<CreatedWishlistDto> IRequestHandler<CreateWishlistCommand, CreatedWishlistDto>.Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
        {
            var wishlist = new Wishlist { CustomerId = request.CustomerId, Name = request.Name };

            var data = await _uow.GetRepository<Wishlist>().CreateAsync(wishlist);
            await _uow.SaveChangesAsync();

            return _mapper.Map<CreatedWishlistDto>(data);
        }
    }
}
