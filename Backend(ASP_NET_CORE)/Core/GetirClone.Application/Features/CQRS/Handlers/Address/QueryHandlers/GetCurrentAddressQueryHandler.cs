using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries.Address;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetCurrentAddressQueryHandler : IRequestHandler<GetCurrentAddressQuery, AddressListDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;


        public GetCurrentAddressQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AddressListDto> Handle(GetCurrentAddressQuery request, CancellationToken cancellationToken)
        {
            var currentAddress = await _uow.GetRepository<Address>().GetByFilterAsync(a => a.CustomerId == request.CustomerId && a.IsPrimary, cancellationToken);
            var dto = _mapper.Map<AddressListDto>(currentAddress);
            return dto;
        }
    }
}
