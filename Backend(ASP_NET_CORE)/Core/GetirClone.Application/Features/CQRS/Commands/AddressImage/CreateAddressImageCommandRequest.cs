using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class CreateAddressImageCommand : IRequest
    {
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageString { get; set; }
    }
}
