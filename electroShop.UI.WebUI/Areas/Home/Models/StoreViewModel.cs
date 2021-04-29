using ElectroShop.Service.Application;
using ElectroShop.Service.Application.Categorys;
using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.Models
{
    public class StoreViewModel
    {
        public List<ProductDto> Products { get; set; }
        public PagedAndSorted PagedAndSorted { get; set; }
        public string SelectCategory { get; set; }
        public string Show { get; set; }

    }
}
