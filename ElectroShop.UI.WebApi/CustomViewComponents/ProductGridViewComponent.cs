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
    [ViewComponent(Name = "ProductGrid")]
    public class ProductGridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Title = "")
        {

            var Client = new HttpClient();
            var url = "https://localhost:44359/api/v1/product";

            var Body = await Client.GetStringAsync(url);

            List<ProductViewModel> GetAll = JsonConvert.DeserializeObject<List<ProductViewModel>>(Body);

           
            ViewBag.Product = GetAll.Where(c => string.IsNullOrWhiteSpace(ViewBag?.SelectCategory) ? true : c.Category.Name == ViewBag.SelectCategory).ToList();
            ViewBag.SectionTitle = Title;

            return View();

        }
    }
}
