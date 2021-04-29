using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Infrasctures.Data.Ef
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
       
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
         
        }

        

        public void Commit()
        {
            context.SaveChanges();
        }

       
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }
    }
}
