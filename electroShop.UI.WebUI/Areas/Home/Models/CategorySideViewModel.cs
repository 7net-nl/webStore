using ElectroShop.Service.Application.Categorys;
using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.Models
{
    public class CategorySideViewModel
    {
        public List<ProductDto> Products { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public string SelectCategory { get; set; }
    }
}
