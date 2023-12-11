using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(new List<ProductType>
            {
                new()
                {
                    Id=1,
                    Type="SingleProduct"
                },
                new()
                {
                    Id= 2,
                    Type="Package"
                }
            });
        }
    }
}
