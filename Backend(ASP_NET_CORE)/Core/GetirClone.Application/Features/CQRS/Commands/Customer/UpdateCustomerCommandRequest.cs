using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
