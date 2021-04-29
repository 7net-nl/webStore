using electroShop.UI.WebUI.Areas.Home.Models;
using ElectroShop.Service.Application.Categorys;
using ElectroShop.Service.Application.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.CustomViewComponents
{
    [ViewComponent(Name ="CategorySide")]
    public class CategorySideViewComponent : ViewComponent
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public CategorySideViewComponent(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke(string Category="")
        {
            var GetAllProduct = productService.GetAll();
            var GetAllCategory = categoryService.GetAll();
            var model = new CategorySideViewModel
            {
                   Categories = GetAllCategory,
                    Products = GetAllProduct,
                     SelectCategory = Category
            };
             
            return View(model);
        }
    }
}
