using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            int Index = 1;
            foreach (Application.Enums.AddressType addressType in Enum.GetValues(typeof(Application.Enums.AddressType)))
            {
                builder.HasData(new AddressType
                {
                    Id = Index++,
                    Title = $"{addressType}"
                });
            }
        }
    }
}
