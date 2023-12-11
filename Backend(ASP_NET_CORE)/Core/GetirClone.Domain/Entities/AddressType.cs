namespace GetirClone.Domain.Entities
{
    public class AddressType
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
