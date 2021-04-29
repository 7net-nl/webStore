using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Filters
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {

            var Text = "<h1>در برنامه خطایی رخ داده</h1>";
            var _byte = ASCIIEncoding.UTF8.GetBytes(Text);
            context.HttpContext.Response.Body.Write(_byte);
        }

    }
}
