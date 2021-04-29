using electroShop.UI.WebUI.Resources;
using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using ElectroShop.Infrasctures.Data.Ef;
using ElectroShop.Infrasctures.Data.Ef.Repositories;
using ElectroShop.Service.Application.Categorys;
using ElectroShop.Service.Application.Customers;
using ElectroShop.Service.Application.Orders;
using ElectroShop.Service.Application.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.StartupExtension
{
    public static class ServicesExtension
    {
        public static void SevicesCollection(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddSingleton(c => new ResourceManager(typeof(MyResources)));
            services.AddSingleton<LocalizationString, LocalizationString>();
        }
    }
}
