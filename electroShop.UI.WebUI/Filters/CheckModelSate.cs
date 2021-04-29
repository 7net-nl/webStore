using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Filters
{
    public class CheckModelSate : ActionFilterAttribute
    {
        
       
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
               
                context.Result = new RedirectToActionResult("SignUp", "Home", new {Erorr= "خطای ورودی اشتباه دوباره سعی فرمایید" });
            }
          
        }



    }
}
