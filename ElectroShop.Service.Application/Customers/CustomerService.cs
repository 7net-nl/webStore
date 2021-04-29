using AutoMapper;
using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using ElectroShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ElectroShop.Service.Application.Customers
{
    public class CustomerService : BaseService<Customer, CustomerDto, int>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork, IBaseRepository baseRepository, IMapper mapper) : base(unitOfWork, baseRepository, mapper)
        {
        }

      



    }
}
