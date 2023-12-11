using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasMany(d => d.CartDiscountRelations).WithOne(cdr => cdr.Discount).HasForeignKey(cdr => cdr.DiscountId);
            builder.HasMany(d => d.ProductDiscountRelations).WithOne(pdr => pdr.Discount).HasForeignKey(pdr => pdr.DiscountId);

            builder.Property(d => d.Amount).HasPrecision(18, 2);
            builder.Property(d => d.Percentage).HasPrecision(18, 2);
        }
    }
}
