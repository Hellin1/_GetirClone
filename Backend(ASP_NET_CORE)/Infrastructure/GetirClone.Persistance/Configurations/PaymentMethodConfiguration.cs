using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {

            builder.HasData(new List<PaymentMethod>
            {
                new()
                {
                    Id = 1,
                    MethodName = "Kredi/Banka",
                },
                new()
                {
                    Id=2,
                    MethodName = "BKM Express"
                }
            });
        }
    }
}
