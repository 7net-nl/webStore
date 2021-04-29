using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.Web.Models
{
    public class OrderViewModel
    {
        public long ID { get; set; }
        public int Product_ID { get; set; }
        public ProductViewModel Product { get; set; }
        public byte Quntity { get; set; }
        public int Customer_ID { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
