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
    [ViewComponent(Name ="ProductDetail")]
    public class ProductDetailViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id=0)
        {
            var Client = new HttpClient();
            var url = "https://localhost:44359/api/v1/Product/" + Id;
            var Body = await Client.GetStringAsync(url);
            var model = JsonConvert.DeserializeObject<ProductViewModel>(Body);
            ViewBag.SelectCategory = model.Category.Name;

            return View(model);
        }
    }
}
