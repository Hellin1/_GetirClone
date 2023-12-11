using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class WishlistListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<ProductWishlistListDto>? ProductWishlists { get; set; }
    }
}
