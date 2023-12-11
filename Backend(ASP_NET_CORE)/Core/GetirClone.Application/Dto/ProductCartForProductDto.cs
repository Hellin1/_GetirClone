using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class ProductCartForProductDto
    {
        public int ProductId { get; set; }

        public ProductListDto? Product { get; set; }

        public int CartId { get; set; }

        public int Quantity { get; set; }

        public List<Discount>? Discounts { get; set; }
    }
}
