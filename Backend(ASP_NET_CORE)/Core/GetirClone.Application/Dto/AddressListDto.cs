using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class AddressListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AddressString { get; set; }
        public string BuildingNumber { get; set; }
        public string Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public string AddressDirections { get; set; }
        public bool IsPrimary { get; set; }
        public AddressType? AddressType { get; set; }
        public AddressImage? AddressImage { get; set; }
    }
}