using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class ShipmentStatesConfiguration : IEntityTypeConfiguration<ShipmentStates>
    {
        public void Configure(EntityTypeBuilder<ShipmentStates> builder)
        {
            builder.HasData(new List<ShipmentStates>
            {
                new()
                {
                    Id = 1,
                    Name = "Sipariş Alındı",
                    Description = "Sipariş Alındı",

                },
                new()
                {
                    Id = 2,
                    Name = "Siparis Hazırlanıyor",
                    Description = "Siparis Hazırlanıyor",
                },
                new()
                {
                    Id=3,
                    Name="Kurye Yolda",
                    Description="Kurye Yolda",
                },
                new()
                {
                    Id = 4,
                    Name = "Teslim Edildi",
                    Description = "Teslim Edildi",
                }
            });
        }
    }
}