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
    [ViewComponent(Name ="Order")]
    public class OrderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Client = new HttpClient();
            var url = "https://localhost:44359/api/v1/Order";
            var Body = await Client.GetStringAsync(url);
            var GetAll = JsonConvert.DeserializeObject<List<OrderViewModel>>(Body);
            ViewBag.Order = GetAll;
            
            return View();
        }
    }
}
