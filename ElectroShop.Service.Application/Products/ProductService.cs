using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using ElectroShop.Domain.Entities;
using ElectroShop.Service.Application.Categorys;
using ElectroShop.Service.Application.Files;
using static System.Net.Mime.MediaTypeNames;

namespace ElectroShop.Service.Application.Products
{
    public class ProductService : BaseService<Product, ProductDto, int>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IBaseRepository baseRepository, IMapper mapper) : base(unitOfWork, baseRepository, mapper)
        {
        }

        public override List<ProductDto> GetAll()
        {
            var GetAll = GetAllInclude(c => c.Category, c => c.Images);
            GetAll.All(c=>c.Images.All(d => { d.Product = null; return true; }));

            return EntityToDto(GetAll);
        }

        public override ProductDto Find(int key)
        {
            var Product = from product in baseRepository.GetAll<Product>() where product.ID == key
                          join images in baseRepository.GetAll<FFiles>() on product.ID equals images.Product_ID into dbimages
                          join category in baseRepository.GetAll<Category>() on product.Category_ID equals category.ID into dbcategory
                          select product;

            Product.LastOrDefault().Images.All(c => { c.Product = null; return true; });

            return EntityToDto(Product.LastOrDefault());
        }


        public override List<Product> GetAllWithIncludeOrNo()
        {
            var GetAllInc = GetAllInclude(c => c.Category, c => c.Images);
            GetAllInc.All(c => c.Images.All(d => { d.Product = null; return true; }));

            return GetAllInc;
        }



    }
}
