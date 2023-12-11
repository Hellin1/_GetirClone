using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class AddressImageConfiguration : IEntityTypeConfiguration<AddressImage>
    {
        public void Configure(EntityTypeBuilder<AddressImage> builder)
        {

            List<string> ImageUrls = new List<string>()
            {
                "https://cdn.getir.com/address-emojies/House.svg",
                "https://cdn.getir.com/address-emojies/Plaza.svg",
                "https://cdn.getir.com/address-emojies/Park.svg",
                "https://cdn.getir.com/address-emojies/Apartment.svg",
                "https://cdn.getir.com/address-emojies/Apple.svg",
                "https://cdn.getir.com/address-emojies/Basket.svg",
                "https://cdn.getir.com/address-emojies/Book.svg",
                "https://cdn.getir.com/address-emojies/Cat.svg",
                "https://cdn.getir.com/address-emojies/Chair.svg",
                "https://cdn.getir.com/address-emojies/Chick.svg",
                "https://cdn.getir.com/address-emojies/Dog.svg",
                "https://cdn.getir.com/address-emojies/Family.svg",
                "https://cdn.getir.com/address-emojies/Fish.svg",
                "https://cdn.getir.com/address-emojies/Football.svg",
                "https://cdn.getir.com/address-emojies/Gift.svg",
            };

            int Index = 1;

            foreach (Application.Enums.AddressImage addressImage in Enum.GetValues(typeof(Application.Enums.AddressImage)))
            {
                builder.HasData(new List<AddressImage>
                {
                    new()
                    {
                        Id = Index++,
                        Title = $"{addressImage}",
                        ImageUrl = Index >= ImageUrls.Count-1 ? "" : ImageUrls[Index-1]
                    }
                });
            }
        }
    }
}
