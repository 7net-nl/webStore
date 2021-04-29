using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.StartupExtension
{
    public static class AthenticationExtension
    {
        public static void AthenticationCustom(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddAuthentication().AddGoogle(option =>
            {
                option.ClientId = Configuration["Athentication:Google:ClientID"];
                option.ClientSecret = Configuration["Athentication:Google:Secret"];
                option.CallbackPath = new PathString("/Users/Login/Index");

            });

            services.AddAuthentication().AddFacebook(option =>
            {
                option.AppId = Configuration["Athentication:FaceBook:AppID"];
                option.AppSecret = Configuration["Athentication:FaceBook:AppSecret"];

            });

            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Users/Home/SignIn";
                option.LogoutPath = "/Users/Home/SignOut";
                option.AccessDeniedPath = "/Users/Home/AccessDenied";
            });

            services.AddAuthentication().AddOpenIdConnect(option =>
            {
                
                option.ClientId = "mvc";
                option.ClientSecret = "secret";
                option.Authority = "https://localhost:44302/";
                option.GetClaimsFromUserInfoEndpoint = true;
                
            });


        }
    }
}
