using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class CartsConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasMany(c => c.ProductCarts).WithOne(pc => pc.Cart).HasForeignKey(pc => pc.CartId);

            builder.Property(c => c.TotalPrice).HasPrecision(19, 4);

            builder.HasOne(c => c.Customer).WithOne(cu => cu.Cart).HasForeignKey<Cart>(cu => cu.CustomerId);


            builder.HasMany(c => c.CartDiscountRelations).WithOne(cdr => cdr.Cart).HasForeignKey(cdr => cdr.CartId);


            builder.Property(c => c.BagPrice).HasPrecision(19, 4);
            builder.Property(c => c.DeliveryFee).HasPrecision(19, 4);

        }
    }
}
