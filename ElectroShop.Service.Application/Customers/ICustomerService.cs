using ElectroShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Service.Application.Customers
{
   public interface ICustomerService : IBaseService<Customer,CustomerDto,int>
    {
    }
}
