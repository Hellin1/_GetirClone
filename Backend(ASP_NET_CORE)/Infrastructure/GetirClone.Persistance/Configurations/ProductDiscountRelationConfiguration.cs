using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class ProductDiscountRelationConfiguration : IEntityTypeConfiguration<ProductDiscountRelation>
    {
        public void Configure(EntityTypeBuilder<ProductDiscountRelation> builder)
        {
            builder.HasKey(pdr => new { pdr.ProductId, pdr.DiscountId });
        }
    }
}
