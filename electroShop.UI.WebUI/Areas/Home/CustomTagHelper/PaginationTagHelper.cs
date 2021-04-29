using ElectroShop.Service.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Home.CustomTagHelper
{
    [HtmlTargetElement("div",Attributes ="Pagination")]
    public class PaginationTagHelper:TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public string PagingAction { get; set; }
        public string PagingController { get; set; }
        public PagedAndSorted Pagination { get; set; }
        public PaginationTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var UrlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            var ItemOnThePage = ((Pagination.SelectPage * Pagination.PageItemCount) > Pagination.Count) ? Pagination.Count : Pagination.SelectPage * Pagination.PageItemCount;
             var HtmlCode = $@"<div class=""store-filter clearfix"">
                      <span class=""store-qty"">مشاهده محصولات {ItemOnThePage} از {Pagination.Count} تا کل محصولات</span>
                    <ul class=""store-pagination"">";
            for (short i = 1; i <= Pagination.TotalPage; i++)
            {
                if(i==Pagination.SelectPage)
                {
                    HtmlCode = HtmlCode + $@"<li class=""active"">{i}</li>";
                }
                else
                {
                    

                    HtmlCode = HtmlCode + $@"<li><a href=""{UrlHelper.Action(PagingAction,PagingController,new { Page = i })}"">{i}</a></li>";
                }
            }
            HtmlCode = HtmlCode + @"</ul></div>";

            output.SuppressOutput();
            output.Content.AppendHtml(HtmlCode);
        }
    }
}
