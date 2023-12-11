using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class ProductWishlistConfiguration : IEntityTypeConfiguration<ProductWishlist>
    {
        public void Configure(EntityTypeBuilder<ProductWishlist> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.WishlistId });
        }
    }
}
