using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasMany(w => w.ProductWishlists).WithOne(pw => pw.Wishlist).HasForeignKey(pw => pw.WishlistId);
        }
    }
}
