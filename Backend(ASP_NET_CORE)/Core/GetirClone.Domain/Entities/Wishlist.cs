namespace GetirClone.Domain.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ProductWishlist> ProductWishlists { get; set; }
    }
}
