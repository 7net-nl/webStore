using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ElectroShop.UI.OAuth.Infrasctures
{
    public class MyConFigurationDbContext : ConfigurationDbContext<MyConFigurationDbContext>
    {
        public MyConFigurationDbContext(DbContextOptions<MyConFigurationDbContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
