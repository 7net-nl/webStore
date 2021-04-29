using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop.UI.Api.Filters
{
    public class CheckException: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 406;
            var Message = "در برنامه خطایی رخ داده است";
            var ToByte = ASCIIEncoding.UTF8.GetBytes(Message);
            context.HttpContext.Response.Body.Write(ToByte,0,ToByte.Length);
        }
    }
}
