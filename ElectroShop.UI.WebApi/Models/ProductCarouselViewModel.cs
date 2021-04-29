using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.Web.Models
{
    public class ProductCarouselViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public string Title { get; set; }
    }
}
