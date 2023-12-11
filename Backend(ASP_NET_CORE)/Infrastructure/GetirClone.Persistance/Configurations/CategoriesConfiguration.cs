using GetirClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirClone.Persistance.Configurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(c => c.ParentCategory)
             .WithMany(c => c.SubCategories)
             .HasForeignKey(c => c.ParentCategoryId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Category>
            {
                new Category
                {
                    Id = 12,
                    Name = "Su & İçecek",
                    ImageUrl = "http://cdn.getir.com/cat/551430043427d5010a3a5c5e_1619242669958_1619242670038.jpeg"
                },
                new Category
                {
                    Id = 13,
                    Name = "Meyve & Sebze",
                    ImageUrl="http://cdn.getir.com/cat/5928113e616cab00041ec6de_1619242870968_1619242871055.jpeg"
                },
                new Category
                {
                    Id = 16,
                    Name = "Fırından",
                    ImageUrl="http://cdn.getir.com/cat/566eeb85f9facb0f00b1cb16_1619242817768_1619242817849.jpeg"
                },
                new Category
                {
                    Id = 17,
                    Name="Temel Gıda",
                    ImageUrl="http://cdn.getir.com/cat/56dfcfba86004203000a870d_1619242834654_1619242834734.jpeg"
                },
                new Category
                {
                    Id = 18,
                    Name = "Atıştırmalık",
                    ImageUrl="http://cdn.getir.com/cat/56dfe03cf82055030022cdc0_1619242841966_1619242842053.jpeg"
                },
                new Category
                {
                    Id = 19,
                    Name = "Dondurma",
                    ImageUrl="http://cdn.getir.com/cat/55bca8484dcda90c00e3aa80_1619242741382_1619242741482.jpeg"
                },
                new Category
                {
                    Id = 20,
                    Name = "Süt Ürünleri",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/00291222-f892-40f7-ae73-805d0fcff0ec.jpeg"
                },
                new Category
                {
                    Id = 21,
                    Name = "Kahvaltılık",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/8b3ca6ef-879c-44e9-885b-9bdf1a7c2d03.jpeg"
                },
                new Category
                {
                    Id = 22,
                    Name = "Yiyecek",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/da88cf5c-badb-4114-ac60-d2eab214fcc5.jpeg"
                },
                new Category
                {
                    Id = 23,
                    Name = "Fit & Form",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/b6a1cabf-a848-46f1-9a8a-862dba8657c2.jpeg"
                },
                new Category
                {
                    Id = 24,
                    Name = "Kişisel Bakım",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/6a82d3cd-7e98-490c-948b-98a74929af8c.jpeg"
                },
                new Category
                {
                    Id = 25,
                    Name = "Ev Bakım",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/6c63f668-cec4-48a4-bd57-66c87dc0df93.jpeg"
                },
                new Category
                {
                    Id = 26,
                    Name = "Ev & Yaşam",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/cbbc82b3-dfef-43e8-a1a0-778002cc77ff.jpeg"
                },
                new Category
                {
                    Id = 27,
                    Name = "Teknoloji",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/71f10e45-7d0e-4484-b8d1-1b1e2dd1ec22.jpeg"
                },
                new Category
                {
                    Id = 28,
                    Name = "Evcil Hayvan",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/2c53a233-5a7d-405b-9cb5-e0ae64b59fb4.jpeg"
                },
                new Category
                {
                    Id = 29,
                    Name = "Bebek",
                    ImageUrl="https://market-product-images-cdn.getirapi.com/category/711050f1-d642-4c03-967c-7a26d1d2357d.jpeg"
                },

            });
        }
    }
}
