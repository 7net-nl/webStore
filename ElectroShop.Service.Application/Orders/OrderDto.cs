using ElectroShop.Service.Application.Customers;
using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Service.Application.Orders
{
      public class OrderDto
    {
        public long ID { get; set; }
        public int Product_ID { get; set; }
        public ProductDto Product { get; set; }
        public byte Quntity { get; set; }
        public int Customer_ID { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
