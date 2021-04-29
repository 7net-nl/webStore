using AutoMapper;
using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using ElectroShop.Domain.Entities;

namespace ElectroShop.Service.Application.Categorys
{
    public class CategoryService : BaseService<Category, CategoryDto, byte>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IBaseRepository baseRepository, IMapper mapper) : base(unitOfWork, baseRepository, mapper)
        {
        }
    }
}
