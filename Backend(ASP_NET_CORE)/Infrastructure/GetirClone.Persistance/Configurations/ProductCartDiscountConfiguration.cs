using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class ProductCartDiscountConfiguration : IEntityTypeConfiguration<ProductCartDiscounts>
    {
        public void Configure(EntityTypeBuilder<ProductCartDiscounts> builder)
        {
            builder.HasKey(pcd => new { pcd.ProductId, pcd.DiscountId, pcd.CartId });


            builder.HasOne(pcd => pcd.ProductCart)
           .WithMany()
           .HasForeignKey(pcd => new { pcd.ProductId, pcd.CartId });

            builder.HasOne(pcd => pcd.Discount)
            .WithMany()
            .HasForeignKey(pcd => pcd.DiscountId);
        }
    }
}
