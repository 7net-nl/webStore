using ElectroShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Cart.Models
{
    public class CheckOutViewModel
    {
        public List<CartViewModel> Carts { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quntity { get; set; }
        public InfoPersonViewModel InfoPerson { get; set; }
        public EnumInfoPay InfoPay { get; set; }
        public bool Terms { get; set; }

      
    }
}
