using ElectroShop.Domain.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Domain.Contract.Interface
{
      public interface IUnitOfWork
    {

       
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Commit();

      




    }
}
