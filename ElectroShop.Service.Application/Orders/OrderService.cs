using AutoMapper;
using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using ElectroShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ElectroShop.Service.Application.Orders
{
    public class OrderService : BaseService<Order, OrderDto, long>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IBaseRepository baseRepository, IMapper mapper) : base(unitOfWork, baseRepository, mapper)
        {
        }

        public override List<Order> GetAllWithIncludeOrNo()
        {
            return GetAllInclude(c => c.Customer, c => c.Product);
        }

        public override List<OrderDto> GetAll()
        {
            return EntityToDto(GetAllWithIncludeOrNo());
        }

    }
}
