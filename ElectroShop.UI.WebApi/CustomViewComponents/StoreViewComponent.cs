using ElectroShop.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ElectroShop.UI.Web.CustomViewComponents
{
    [ViewComponent(Name ="Store")]
    public class StoreViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Client = new HttpClient();
            var url = "https://localhost:44359/api/v1/Product";
            var Body = await Client.GetStringAsync(url);
            var GetAll = JsonConvert.DeserializeObject<List<ProductViewModel>>(Body);
            byte SelectPage = ViewBag?.SelectPage;
            byte PageItem = ViewBag?.PageItem;
            var Count = GetAll.Where(c => string.IsNullOrWhiteSpace(ViewBag?.SelectCategory) ? true : c.Category.Name == ViewBag?.SelectCategory).Count();
            var PageCount = Count / (double)ViewBag.PageItem;
            var TotalPage = Math.Ceiling(PageCount);
            ViewBag.TotalPage = TotalPage;
            ViewBag.ProductCount = Count;
            ViewBag.ProductSeeCount = ViewBag?.SelectPage * ViewBag?.PageItem;
            if (ViewBag?.ProductSeeCount > Count) ViewBag.ProductSeeCount = Count;

            ViewBag.Product = GetAll.Where(c=> string.IsNullOrWhiteSpace(ViewBag?.SelectCategory) ? true : c.Category.Name == ViewBag?.SelectCategory).OrderBy(c=>c.ID).Skip((SelectPage-1)*PageItem).Take(PageItem).ToList();

         

            return View();
        }
    }
}
