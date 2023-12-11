using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class RemoveCustomerCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
