namespace GetirClone.Domain.Entities
{
    public class AddressImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageString { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
