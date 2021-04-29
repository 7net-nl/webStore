using ElectroShop.Domain.Entities;
using ElectroShop.Service.Application.Categorys;
using ElectroShop.Service.Application.Files;
using System;
using System.Collections.Generic;

namespace ElectroShop.Service.Application.Products
{
    public class ProductDto 
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FilesDto> Images { get; set; }
        public int? Rate { get; set; }
        public EnumType Type { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Category_ID { get; set; }
        public CategoryDto Category { get; set; }
    }
}
