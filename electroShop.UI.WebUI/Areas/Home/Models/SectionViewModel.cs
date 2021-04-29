using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.Models
{
    public class SectionViewModel
    {
        public List<ProductDto> Products { get; set; }
        public string Title { get; set; }
    }
}
