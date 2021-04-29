using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });

            services.AddMvc().AddSessionStateTempDataProvider();

            services.Configure<RazorViewEngineOptions>(option =>
            {
                option.ViewLocationFormats.Add("/Views/Shared/Partial/{0}.cshtml");
            });


            services.AddAuthentication(option =>
            {
                option.DefaultScheme = "Cookies";
                option.DefaultChallengeScheme = "oidc";
                

            }).AddCookie("Cookies")
            .AddOpenIdConnect("oidc",option=> 
            {
                option.SignInScheme = "Cookies";
                option.Authority = "https://localhost:44302";
                option.ClientId = "mvc";
                option.ClientSecret = "secret";
                option.GetClaimsFromUserInfoEndpoint = true;

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
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");



            });

        }
    }
}
