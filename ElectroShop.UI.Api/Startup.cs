using AutoMapper;
using ElectroShop.Infrasctures.Data.Ef;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ElectroShop.UI.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddApplicationService();
            services.AddAutoMapper();
            services.AddSession();
            services.AddMemoryCache();

            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(option =>
            {
                option.Authority = "https://localhost:44302";
                option.ApiName = "MyApi";
            });

            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("default")));
           
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "ElectroShop", Version = "v1", Description = "electroShop Test Api" });
            });

            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddCors(c => c.AddPolicy("HealthPolicy", builder =>
               {
                   builder.AllowAnyHeader();
                   builder.AllowAnyMethod();
                   builder.AllowAnyOrigin();
               }));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI(Option =>
            {
                Option.SwaggerEndpoint("/swagger/v1/swagger.json", "ElectroShop Api");
            });
            app.UseMvc();
        }
    }
}
