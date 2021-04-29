using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using AutoMapper;
using electroShop.UI.WebUI.Areas.Home.Models;
using electroShop.UI.WebUI.Filters;
using electroShop.UI.WebUI.Resources;
using ElectroShop.Domain.Entities;
using ElectroShop.Service.Application;
using ElectroShop.Service.Application.Categorys;
using ElectroShop.Service.Application.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace electroShop.UI.WebUI.Areas.Home.Controllers
{
    [Area("Home")]
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IOptions<Language> option;

        public HomeController(IProductService productService,ICategoryService categoryService,IOptions<Language> option)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.option = option;
        }
 
        public IActionResult Index(string Lang="en")
        {
            ///Cookie
            Response.Cookies.Append("Lang", Lang);
            ////Session
            HttpContext.Session.SetString("Lang", Lang);
            ///Or For Implement Localization AppSetting.json
            ViewBag.Lang = option.Value.English;
            ///viewbag
            ViewBag.Lang = Lang; 
            var GetAll = productService.GetAll();
            var model = new ProductViewModel
            {
                ProductCorting = GetAll.Where(c=>c.Type==EnumType.Discount).OrderBy(c => c.ID).Take(12).ToList(),
                 ProductNew = GetAll.Where(c=>c.Type==EnumType.New || c.Type == EnumType.NewAndDiscount).OrderBy(c=>c.ID).Take(12).ToList(),
                  ProductUpSales = GetAll.Where(c=>c.Type == EnumType.NewAndDiscount).OrderBy(c=>c.ID).Take(12).ToList() ,
                   ProductRandom = GetAll.Where(c=>c.Type == EnumType.New || c.Type == EnumType.NewAndDiscount || c.Type == EnumType.Discount).OrderBy(c=>c.ID).Take(12).ToList()
            };

            return View(model);
        }

        public IActionResult Detail(int Id=0)
        {
           
            var Product = productService.Find(Id);
            var model = new DetailViewModel
            {
                Product = Product,
                 RelatedProduct = productService.GetAll().Where(c=>c.Category_ID == Product.Category_ID).OrderBy(c=>c.ID).Take(4).ToList(),
                CurrentPage = "مشخصات کالا"
                //CurrentPage = Request.Path.Value
            };
            return View(model);
        }

        public IActionResult Store(short Page = 1, string Category = null, short PageItemCount = 9)
        {
            GetProduct(Page, Category, PageItemCount, out PagedAndSorted Paging, out List<ProductDto> GetAll);

            SelectListPageItem(Category, PageItemCount);

        

            var model = new StoreViewModel
            {
                Products = GetAll,
                PagedAndSorted = Paging,
                SelectCategory = Category

            };

            return View(model);
        }

      


        public IActionResult Search(string q)
        {
            var SearchTotal = productService.GetAll().Where(c => c.Description.IndexOf(q) > 0 ||
                              c.Title.IndexOf(q) > 0).OrderBy(c => c.ID).ToList();
            var model = new SearchViewModel
            {
                 Product = SearchTotal
            };

            return View(model);
        }

       

        private void GetProduct(short Page, string Category, short PageItemCount, out PagedAndSorted Paging, out List<ProductDto> GetAll)
        {
            Paging = new PagedAndSorted
            {
                SelectPage = Page,
                PageItemCount = PageItemCount

            };
            Paging = productService.Paging(Paging, c => !string.IsNullOrEmpty(Category) ? c.Category.Name == Category : true);
            GetAll = productService.GetAll(Paging, c => !string.IsNullOrEmpty(Category) ? c.Category.Name == Category : true, c => c.ID);
        }
        private void SelectListPageItem(string Category, short PageItemCount)
        {
            var ListPageItemCount = new List<SelectListItem>
            {
                new SelectListItem { Value = Url.Action("Store", "Home", new { Category, PageItemCount = 9 }), Text = "9", Selected = PageItemCount == 9 ? true:false },
                new SelectListItem { Value = Url.Action("Store", "Home", new { Category, PageItemCount = 12 }), Text = "12", Selected = PageItemCount == 12 ? true:false },
                new SelectListItem { Value = Url.Action("Store", "Home", new { Category, PageItemCount = 20 }), Text = "20", Selected = PageItemCount == 20 ? true:false },
                new SelectListItem { Value = Url.Action("Store", "Home", new { Category, PageItemCount = 30 }), Text = "30", Selected = PageItemCount == 30 ? true:false }
            };


            ViewBag.ListPageItemCount = ListPageItemCount;
        }

      

    }
}
