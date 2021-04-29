using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ElectroShop.Domain.Contract.Repositories
{
      public interface IBaseRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity:class;
        void Update<TEntity>(TEntity entity) where TEntity:class;
        void Delete<TEntity,TPrimaryKey>(TPrimaryKey Key) where TEntity:class where TPrimaryKey:struct;
        TEntity Find<TEntity,TPrimaryKey>(TPrimaryKey Key) where TEntity:class where TPrimaryKey:struct;
        List<TEntity> GetAll<TEntity>() where TEntity:class;
        IQueryable<TEntity> AllInclude<TEntity>(params Expression<Func<TEntity,object>>[] AllInclude) where TEntity : class;


    }
}
