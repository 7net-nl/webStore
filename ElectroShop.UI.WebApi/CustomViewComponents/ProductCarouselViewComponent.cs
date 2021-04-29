using ElectroShop.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static ElectroShop.UI.Web.Models.Enums;

namespace ElectroShop.UI.Web.CustomViewComponents
{
    [ViewComponent(Name ="ProductCarousel")]
    public class ProductCarouselViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Title="",string ProductSelection="")
        {

            var Client = new HttpClient();
            var url = "https://localhost:44359/api/v1/product";

            var Body = await Client.GetStringAsync(url);

            List<ProductViewModel> GetAll = JsonConvert.DeserializeObject<List<ProductViewModel>>(Body);

            

            switch (ProductSelection)
            {
                case "Corting":
                ViewBag.Product = GetAll.Where(c => c.Type == "1" || c.Type == "2" || c.Type == "3").ToList();
                break;
                case "News":
                ViewBag.Product = GetAll.Where(c => c.Type == "0" || c.Type == "3").ToList();
                break;
                default:
                ViewBag.Product = GetAll.ToList();
                break;
                   
            }


            ViewBag.SectionTitle = Title;

            return View();
        }
    }

}
