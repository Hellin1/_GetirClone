using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Shipment).WithMany(s => s.Orders).HasForeignKey(o => o.ShipmentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Order>(o => o.PaymentId).OnDelete(DeleteBehavior.NoAction);


            builder.Property(o => o.Date).HasDefaultValueSql("getdate()");

            builder.Property(o => o.TotalPrice).HasPrecision(19, 4);
        }
    }
}
