using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.Web.Models
{
    public class ProductViewModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ImagesViewModel> Images { get; set; }
        public byte Rate { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public CategoryViewModel Category { get; set; }

    }
}
