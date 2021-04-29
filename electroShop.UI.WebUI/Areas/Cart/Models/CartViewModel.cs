using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Cart.Models
{
    public class CartViewModel
    {
        public ProductDto Product { get; set; }
        public byte Quntity { get; set; }
        public decimal TotalPrice => Product.DiscountPrice == null ? Product.Price * Quntity : (decimal)Product.DiscountPrice * Quntity;
    }
}
