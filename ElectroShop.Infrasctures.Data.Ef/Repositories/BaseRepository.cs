using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ElectroShop.Infrasctures.Data.Ef.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext context;

        public BaseRepository(IUnitOfWork unitOfWork,AppDbContext context)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
            context.Database.EnsureCreated();
        }
        public void Add<TEntity>(TEntity entity) where TEntity:class
        {
            unitOfWork.Set<TEntity>().Add(entity);


        }

        public void Delete<TEntity, TPrimaryKey>(TPrimaryKey Key) where TEntity:class where TPrimaryKey:struct
        {
            var GetEntity = unitOfWork.Set<TEntity>().Find(Key);
            unitOfWork.Set<TEntity>().Remove(GetEntity);
        }

        public TEntity Find<TEntity, TPrimaryKey>(TPrimaryKey Key) where TEntity : class where TPrimaryKey : struct
        {
            return unitOfWork.Set<TEntity>().Find(Key);
        }

        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {

            return unitOfWork.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> AllInclude<TEntity>(params Expression<Func<TEntity, object>>[] AllInclude) where TEntity : class
        {
            IQueryable<TEntity> Query = unitOfWork.Set<TEntity>();

            foreach (var item in AllInclude)
            {
                Query = Query.Include(item);
            }

            return Query;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            unitOfWork.Set<TEntity>().Update(entity);
        }
    }
}
