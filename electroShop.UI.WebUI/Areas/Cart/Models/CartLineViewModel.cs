using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Cart.Models
{
    public class CartLineViewModel
    {
        public List<CartViewModel> Cart { get; set; }
        public decimal TotalPrice { get; set; }

      
    }
}
