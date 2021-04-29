using ElectroShop.Domain.Entities;
using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.Models
{
    public class ProductViewModel
    {
        public List<ProductDto> ProductCorting { get; set; }
        public List<ProductDto> ProductNew { get; set; }
        public List<ProductDto> ProductUpSales { get; set; }
        public List<ProductDto> ProductRandom { get; set; }
    }
}
