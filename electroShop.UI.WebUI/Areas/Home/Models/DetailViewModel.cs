using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.Models
{
    public class DetailViewModel
    {
        public ProductDto Product { get; set; }
        public List<ProductDto> RelatedProduct { get; set; }
        public string CurrentPage { get; set; }
    }
}
