using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class CartDiscountRelationConfiguration : IEntityTypeConfiguration<CartDiscountRelation>
    {
        public void Configure(EntityTypeBuilder<CartDiscountRelation> builder)
        {
            builder.HasKey(cdr => new { cdr.CartId, cdr.DiscountId });
        }
    }
}
