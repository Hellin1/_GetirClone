using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries.Customer
{
    public class ApproveLoginQuery : IRequest<UserDto>
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
