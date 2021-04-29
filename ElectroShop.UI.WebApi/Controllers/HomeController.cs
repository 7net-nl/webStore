using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ElectroShop.UI.Web.Controllers
{

    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
          

            return View();
        }

        [Authorize]
        public IActionResult Detail(int Id=0)
        {
            return ViewComponent("ProductDetail",new {Id});
        }

        public IActionResult Store(string Category="",byte SelectPage=1,byte PageItem=9)
        {
            ViewBag.SelectCategory = Category;
            ViewBag.SelectPage = SelectPage;
            ViewBag.PageItem = PageItem;

            return ViewComponent("Store");
        }

        public IActionResult Order()
        {
            return ViewComponent("Order");
        }

     
    }
}
