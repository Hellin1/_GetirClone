using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Date).HasDefaultValueSql("getdate()");

            builder.Property(p => p.TotalPrice).HasPrecision(19, 4);
            builder.Property(p => p.DeliveryFee).HasPrecision(19, 4);

        }
    }
}
