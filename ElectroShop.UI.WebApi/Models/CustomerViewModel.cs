using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.Web.Models
{
    public class CustomerViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Tel { get; set; }
        public string Description { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public int Quntity { get; set; }
        public decimal TotalPrice { get; set; }
        public string InfoPay { get; set; }
    }
}
