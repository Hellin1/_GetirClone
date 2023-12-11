namespace GetirClone.Domain.Entities
{
    public class ShipmentStates
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Shipment>? Shipments { get; set; }

    }
}
