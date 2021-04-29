using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Filters
{
    public class RecaptchaGoogle:ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Request.Form["g-recaptcha-response"]))
            {

               
                context.Result = new RedirectToActionResult("SignUp","Home",new {Erorr= "خطای تایید هویت دوباره سعی فرمایید" });
            }
        }
    }
}
