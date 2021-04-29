using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Resources
{
    public class LocalizationString
    {
         
        private readonly ResourceManager resourceManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LocalizationString(ResourceManager resourceManager,IHttpContextAccessor httpContextAccessor)
        {
            this.resourceManager = resourceManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetString(string Value,string Culture)
        {
           
            try
            {
                Value = resourceManager.GetString(Value, new CultureInfo(Culture));
            }
            catch (Exception)
            {

                Value = "";
            }
            
            return Value;
        }

        public string GetString(string Value)
        {
            var GetCookie = httpContextAccessor.HttpContext.Request.Cookies["Lang"];
            var Culture = httpContextAccessor.HttpContext.Session.GetString("Lang");
            try
            {
                Value = resourceManager.GetString(Value, new CultureInfo(Culture));
            }
            catch (Exception)
            {

                Value = "";
            }

            return Value;
        }

    }
}
