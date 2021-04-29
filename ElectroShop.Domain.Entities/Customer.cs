using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Domain.Entities
{
      public class Customer:BaseEntity<int>
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Tel { get; set; }
        public string Description { get; set; }
        public EnumInfoPay InfoPay { get; set; }
        public List<Order> Orders { get; set; }
        public int Quntity { get; set; }
        public decimal TotalPrice { get; set; }
        

    }
}
