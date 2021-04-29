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
    [ViewComponent(Name ="NewsLetter")]
    public class NewsLetterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            

            return View();
        }
    }
}
