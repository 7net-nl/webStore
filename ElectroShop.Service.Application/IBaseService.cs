using ElectroShop.Domain.Contract.Repositories;
using ElectroShop.Domain.Entities;
using ElectroShop.Service.Application.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ElectroShop.Service.Application
{
    public interface IBaseService<TEntity,TentityDto,TPrimaryKey> where TEntity:class where TentityDto:class where TPrimaryKey:struct
    {
        void Add(TentityDto entity);
        void Update(TentityDto entity);
        void Delete(TPrimaryKey key);
        TentityDto Find(TPrimaryKey key);
        List<TentityDto> GetAll();
        PagedAndSorted Paging(PagedAndSorted pagedAndSorted,Func<TEntity,bool> Category);
        List<TentityDto> GetAll(PagedAndSorted pagedAndSorted, Func<TEntity, TPrimaryKey> Sort);
        List<TentityDto> GetAll(PagedAndSorted pagedAndSorted, Func<TEntity, bool> Category, Func<TEntity,TPrimaryKey> Sort);
        List<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] AllInclude);
    }
}
