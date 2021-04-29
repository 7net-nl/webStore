using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Domain.Entities
{
      public class Order:BaseEntity<long>
    {
        public int Product_ID { get; set; }
        public Product Product { get; set; }
        public byte Quntity { get; set; }
        public int Customer_ID { get; set; }
        public Customer Customer { get; set; }
    }
}
