using ElectroShop.Domain.Entities;
using ElectroShop.Service.Application.Orders;
using ElectroShop.Service.Application.Products;
using System.Collections.Generic;

namespace ElectroShop.Service.Application.Customers
{
    public class CustomerDto
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
        public EnumInfoPay InfoPay { get; set; }
        public List<OrderDto> Orders { get; set; }
        public int Quntity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
