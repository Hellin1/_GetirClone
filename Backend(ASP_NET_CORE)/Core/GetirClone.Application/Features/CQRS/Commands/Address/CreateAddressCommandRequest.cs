using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class CreateAddressCommand : IRequest<CreatedEntityDto>
    {
        public Guid CustomerId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }
        public string AddressString { get; set; }
        public string BuildingNumber { get; set; }
        public string Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public string AddressDirections { get; set; }
        public int AddressTypeId { get; set; }
        public int AddressImageId { get; set; }
    }
}