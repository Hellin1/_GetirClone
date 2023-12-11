using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.
            HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

            builder
            .HasMany(c => c.Wishlist)
            .WithOne(w => w.Customer)
            .HasForeignKey(w => w.CustomerId);



            builder.HasMany(c => c.Addresses).WithOne(a => a.Customer).HasForeignKey(a => a.CustomerId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Payments).WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId);

            builder.HasMany(c => c.PaymentCards).WithOne(pc => pc.Customer).HasForeignKey(pc => pc.CustomerId);

            builder.HasIndex(c => c.PhoneNumber).IsUnique();
        }
    }
}
