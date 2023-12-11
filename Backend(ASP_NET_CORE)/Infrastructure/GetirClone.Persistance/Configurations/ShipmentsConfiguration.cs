using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class ShipmentsConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.Property(s => s.Date).HasDefaultValueSql("getdate()");
            builder.HasOne(s => s.Customer).WithMany(c => c.Shipments).HasForeignKey(s => s.CustomerId);
            builder.HasOne(s => s.ShipmentState).WithMany(st => st.Shipments).HasForeignKey(s => s.ShipmentStateId);

        }
    }
}
