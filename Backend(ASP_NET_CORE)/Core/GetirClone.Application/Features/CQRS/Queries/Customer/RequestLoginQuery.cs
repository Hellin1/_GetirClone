using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries.Customer
{
    public class RequestLoginQuery : IRequest<UserDto>
    {
        public string PhoneNumber { get; set; }
    }
}
