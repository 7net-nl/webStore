using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.CustomTagHelper
{
    [HtmlTargetElement(Attributes = "culture")]
    public class LocalizationTagHelper : TagHelper
    {
        private readonly ResourceManager resourceManager;
        public LocalizationTagHelper(ResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }
        
        public string culture { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var GetInnerText = output.GetChildContentAsync().Result.GetContent();
            culture = string.IsNullOrEmpty(culture) == true ? "en" : culture;
            var GetLocalization = "";
            try
            {
               GetLocalization = resourceManager.GetString(GetInnerText, new CultureInfo(culture));
            }
            catch (Exception)
            {

                GetLocalization = "";
            }
           
           
            output.Content.AppendHtml(GetLocalization);
            
        }
    }
}
