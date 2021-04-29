using ElectroShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Infrasctures.Data.Ef
{
   public static class SeedHelper
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { ID=1 , Name="تخفیفات ویژه" },
                new Category { ID=2, Name="لب تاب"},
                new Category {ID=3, Name="موبایل"},
                new Category {ID=4, Name="دوربین"},
                new Category {ID=5, Name="لوازم جانبی"}
            );

           

            builder.Entity<Product>().HasData(
                new Product
                {
                     ID=1,
                    Category_ID = 1,
                    Color = "قرمز",
                    Description = "توضیحات کوتاه درباره محصول",
                    DiscountPrice = 50,
                    Price = 12000000,
                    Rate = 5,
                    Size = "L",
                    Title = "نام محصول",
                    Type = EnumType.NewAndDiscount
                },
                 new Product
                 {
                     ID=2,
                     Category_ID = 2,
                     Color = "آبی",
                     Description = "توضیحات کوتاه درباره محصول",
                     DiscountPrice = 30,
                     Price = 4500000,
                     Rate = 3,
                     Size = "XL",
                     Title = "نام محصول",
                     Type = EnumType.NewAndDiscount
                 },
                  new Product
                  {
                      ID=3,
                      Category_ID = 3,
                      Color = "قرمز",
                      Description = "توضیحات کوتاه درباره محصول",
                      DiscountPrice = null,
                      Price = 5000000,
                      Rate = 5,
                      Size = "L",
                      Title = "نام محصول",
                      Type = EnumType.NewAndDiscount
                  },
                   new Product
                   {
                       ID=4,
                       Category_ID = 4,
                       Color = "قرمز",
                       Description = "توضیحات کوتاه درباره محصول",
                       DiscountPrice = null,
                       Price = 999,
                       Rate = 5,
                       Size = "L",
                       Title = "نام محصول",
                       Type = EnumType.NewAndDiscount
                   },
                     new Product
                     {
                         ID = 5,
                         Category_ID = 1,
                         Color = "قرمز",
                         Description = "توضیحات کوتاه درباره محصول",
                         DiscountPrice = 50,
                         Price = 999,
                         Rate = 5,
                         Size = "L",
                         Title = "نام محصول",
                         Type = EnumType.New
                     },
                 new Product
                 {
                     ID = 6,
                     Category_ID = 2,
                     Color = "Blue",
                     Description = "توضیحات کوتاه درباره محصول",
                     DiscountPrice = 30,
                     Price = 785,
                     Rate = 3,
                     Size = "XL",
                     Title = "نام محصول",
                     Type = EnumType.New
                 },
                  new Product
                  {
                      ID = 7,
                      Category_ID = 3,
                      Color = "Red",
                      Description = "توضیحات کوتاه درباره محصول",
                      DiscountPrice = null,
                      Price = 999,
                      Rate = 5,
                      Size = "L",
                      Title = "نام محصول",
                      Type = EnumType.New
                  },
                   new Product
                   {
                       ID = 8,
                       Category_ID = 4,
                       Color = "Red",
                       Description = "توضیحات کوتاه درباره محصول",
                       DiscountPrice = null,
                       Price = 999,
                       Rate = 5,
                       Size = "L",
                       Title = "نام محصول",
                       Type = EnumType.New
                   },
                     new Product
                     {
                         ID = 9,
                         Category_ID = 1,
                         Color = "Red",
                         Description = "توضیحات کوتاه درباره محصول",
                         DiscountPrice = 50,
                         Price = 999,
                         Rate = 5,
                         Size = "L",
                         Title = "نام محصول",
                         Type = EnumType.Discount
                     },
                 new Product
                 {
                     ID = 10,
                     Category_ID = 2,
                     Color = "Blue",
                     Description = "توضیحات کوتاه درباره محصول",
                     DiscountPrice = 30,
                     Price = 785,
                     Rate = 3,
                     Size = "XL",
                     Title = "نام محصول",
                     Type = EnumType.Discount
                 },
                  new Product
                  {
                      ID = 11,
                      Category_ID = 3,
                      Color = "Red",
                      Description = "توضیحات کوتاه درباره محصول",
                      DiscountPrice = null,
                      Price = 999,
                      Rate = 5,
                      Size = "L",
                      Title = "نام محصول",
                      Type = EnumType.Discount
                  },
                   new Product
                   {
                       ID = 12,
                       Category_ID = 4,
                       Color = "Red",
                       Description = "توضیحات کوتاه درباره محصول",
                       DiscountPrice = null,
                       Price = 999,
                       Rate = 5,
                       Size = "L",
                       Title = "نام محصول",
                       Type = EnumType.Discount
                   }

                );

            builder.Entity<FFiles>().HasData(
              new FFiles { ID = 1, FileName = "product01.png", Product_ID = 1 },
              new FFiles { ID = 2, FileName = "product02.png", Product_ID = 2 },
              new FFiles { ID = 3, FileName = "product03.png", Product_ID = 3 },
              new FFiles { ID = 4, FileName = "product01.png", Product_ID = 4 },
               new FFiles { ID = 5, FileName = "product01.png", Product_ID = 5 },
              new FFiles { ID = 6, FileName = "product02.png", Product_ID = 6 },
              new FFiles { ID = 7, FileName = "product03.png", Product_ID = 7 },
              new FFiles { ID = 8, FileName = "product01.png", Product_ID = 8 },
               new FFiles { ID = 9, FileName = "product01.png", Product_ID = 9 },
              new FFiles { ID = 10, FileName = "product02.png", Product_ID = 10 },
              new FFiles { ID = 11, FileName = "product03.png", Product_ID = 11 },
              new FFiles { ID = 12, FileName = "product01.png", Product_ID = 12 }
          );
        }
    }
}
