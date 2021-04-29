using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop.UI.OAuth.Infrasctures;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroShop.UI.OAuth
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer().
            AddDeveloperSigningCredential().
            AddInMemoryClients(IdentityServerData.GetClients()).
            AddInMemoryIdentityResources(IdentityServerData.GetIdentityResources()).
             AddInMemoryApiResources(IdentityServerData.GetApiResources()).
            AddConfigurationStore<MyConFigurationDbContext>(option =>
            {
                option.ConfigureDbContext = c => c.UseSqlServer(Configuration.GetConnectionString("default"));
            }).AddOperationalStore<MyPersistedGrantDbContext>(option =>
            {
                option.ConfigureDbContext = c => c.UseSqlServer(Configuration.GetConnectionString("default"));
                option.EnableTokenCleanup = true;
                option.TokenCleanupInterval = 30;
            })
            //AddResourceOwnerValidator<Users>();
            
            .AddTestUsers(IdentityServerData.GetTestUsers());
            

            services.AddMvc();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}
