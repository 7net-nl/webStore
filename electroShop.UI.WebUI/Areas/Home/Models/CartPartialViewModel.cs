using electroShop.UI.WebUI.Areas.Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.Models
{
    public class CartPartialViewModel
    {
        public List<CartViewModel> Cart { get; set; }
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }

        
    }
}
