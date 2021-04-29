using AutoMapper;
using electroShop.UI.WebUI.Areas.Users.Data;
using electroShop.UI.WebUI.Areas.Users.Models;
using electroShop.UI.WebUI.Filters;
using electroShop.UI.WebUI.Resources;
using electroShop.UI.WebUI.StartupExtension;
using ElectroShop.Infrasctures.Data.Ef;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace electroShop.UI.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSession();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });

            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddDbContext<UserIdentityDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("identity")));
            services.AddIdentity<MyUser, IdentityRole>().AddEntityFrameworkStores<UserIdentityDbContext>().AddDefaultTokenProviders();

            services.SevicesCollection();
            //services.AthenticationCustom(Configuration);

            services.Configure<Language>(Configuration.GetSection("Language"));
            services.Configure<RecaptchaSettings>(Configuration.GetSection("RecaptchaSettings"));


            services.AddAutoMapper();
            services.AddMvc()
            .AddMvcOptions(option =>
            {
                option.Filters.Add(new ExceptionFilter());
            })
           .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<RazorViewEngineOptions>(option =>
            {
                
                option.AreaViewLocationFormats.Add("/Areas/Home/Views/shared/Partial/{0}.cshtml");
                option.AreaViewLocationFormats.Add("/Areas/Home/Views/shared/_Layout.cshtml");
                
            });

       
       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areaRoute",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                name: "areadefault",
                template: "{area=Home}/{controller=Home}/{action=Index}/{id?}");



            });

        }
    }
}
