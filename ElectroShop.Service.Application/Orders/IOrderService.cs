using ElectroShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Service.Application.Orders
{
   public interface IOrderService : IBaseService<Order,OrderDto,long>
    {
    }
}
