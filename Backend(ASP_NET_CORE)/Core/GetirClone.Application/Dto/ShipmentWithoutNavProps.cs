using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class ShipmentWithoutNavProps
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; }

        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public DateTime Date { get; set; }

    }
}