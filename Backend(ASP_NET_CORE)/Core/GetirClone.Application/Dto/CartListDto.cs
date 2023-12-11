using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class CartListDto
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public decimal BagPrice { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal NeededPriceForFreeDelivery { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal CartAmount { get; set; }
        public string? Note { get; set; }
        public List<ProductCartForProductDto>? ProductCarts { get; set; }
        public List<CartDiscountRelation>? CartDiscountRelations { get; set; }
    }
}
