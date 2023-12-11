using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // product - productdiscount
            builder.HasMany(p => p.ProductDiscountRelations).WithOne(pdr => pdr.Product).HasForeignKey(pdr => pdr.ProductId);

            // Product - Category relationship
            builder
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Products).HasForeignKey(x => x.CategoryId);

            // Product - OrderItem relationship
            builder
                 .HasMany(p => p.OrderItems)
                 .WithOne(p => p.Product)
                 .HasForeignKey(p => p.ProductId);

            // Product - Cart relationship
            builder.HasMany(p => p.ProductCarts).WithOne(pc => pc.Product).HasForeignKey(pc => pc.ProductId);

            // Product - Wishlist relationship
            builder.HasMany(p => p.ProductWishlists).WithOne(pw => pw.Product).HasForeignKey(pw => pw.ProductId);

            builder.HasOne(p => p.ParentProduct)
               .WithMany(p => p.ChildProducts)
               .HasForeignKey(p => p.ParentProductId)
               .OnDelete(DeleteBehavior.Restrict);



            builder.HasOne(p => p.Brand).WithMany(b => b.Products).HasForeignKey(p => p.BrandId);

            builder.Property(p => p.BasePrice).HasPrecision(19, 4);
            builder.Property(p => p.Price).HasPrecision(19, 4);
            builder.Property(p => p.TotalDiscount).HasPrecision(19, 4);
        }
    }
}
