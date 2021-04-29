using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.OAuth.Infrasctures
{
    public class MyPersistedGrantDbContext : PersistedGrantDbContext<MyPersistedGrantDbContext>
    {
        public MyPersistedGrantDbContext(DbContextOptions<MyPersistedGrantDbContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
        {
        }
    }
}
