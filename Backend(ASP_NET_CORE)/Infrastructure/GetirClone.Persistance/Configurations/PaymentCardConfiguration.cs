using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class PaymentCardConfiguration : IEntityTypeConfiguration<PaymentCard>
    {
        public void Configure(EntityTypeBuilder<PaymentCard> builder)
        {
            builder.HasOne(pc => pc.PaymentMethod).WithMany(pm => pm.PaymentCards).HasForeignKey(pc => pc.PaymentMethodId);

            builder.HasIndex(pc => pc.CardNumber).IsUnique();

            builder.HasOne(pc => pc.CardType).WithMany(ct => ct.PaymentCards).HasForeignKey(pc => pc.CardTypeId);

            builder.HasMany(pd => pd.Payments).WithOne(p => p.PaymentCard).HasForeignKey(p => p.PaymentCardId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
