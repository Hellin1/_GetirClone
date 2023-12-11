using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQueryRequest, AddressListDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AddressListDto> Handle(GetAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var address = await _uow.GetRepository<Address>().GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<AddressListDto>(address);
        }
    }
}
