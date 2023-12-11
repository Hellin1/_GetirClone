using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {


            // address - shipment

            builder.HasMany(a => a.Shipments).WithOne(s => s.Address).HasForeignKey(s => s.AddressId);

            // adress - Customer
            builder.HasOne(a => a.Customer).WithMany(c => c.Addresses).HasForeignKey(a => a.CustomerId);

            // address - AddressType
            builder.HasOne(a => a.AddressType).WithMany(at => at.Addresses).HasForeignKey(a => a.AddressTypeId);

            // adress - AddressImage
            builder.HasOne(a => a.AddressImage).WithMany(ai => ai.Addresses).HasForeignKey(a => a.AddressImageId);

        }
    }
}
