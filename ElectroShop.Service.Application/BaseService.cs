using AutoMapper;
using ElectroShop.Domain.Contract.Interface;
using ElectroShop.Domain.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ElectroShop.Service.Application
{
    public abstract class BaseService<TEntity,TEntityDto,TPrimaryKey> : IBaseService<TEntity,TEntityDto,TPrimaryKey>
        where TEntity:class
           where TPrimaryKey:struct
        where TEntityDto:class
    {
        
        
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IBaseRepository baseRepository;
        protected readonly IMapper mapper;

        public BaseService(IUnitOfWork unitOfWork,IBaseRepository baseRepository,IMapper mapper)
        {
            
            this.unitOfWork = unitOfWork;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        
        public virtual void Add(TEntityDto entityDto)
        {
            
            baseRepository.Add(DtoToEntity(entityDto));
            unitOfWork.Commit();
       
        }

       

        public virtual void Delete(TPrimaryKey key)
        {
            baseRepository.Delete<TEntity,TPrimaryKey>(key);
            unitOfWork.Commit();

        }

        public virtual TEntityDto Find(TPrimaryKey key)
        {
            var Product = baseRepository.Find<TEntity, TPrimaryKey>(key);
            return EntityToDto(Product) ;

        }

        public virtual List<TEntityDto> GetAll(PagedAndSorted pagedAndSorted,Func<TEntity,TPrimaryKey> Sort)
        {

            var CustomList = GetAllWithIncludeOrNo().OrderBy(Sort).Skip((pagedAndSorted.PageItemCount * pagedAndSorted.SelectPage) - pagedAndSorted.PageItemCount).Take(pagedAndSorted.PageItemCount).ToList();

            return EntityToDto(CustomList);
        }

        public virtual PagedAndSorted Paging(PagedAndSorted pagedAndSorted,Func<TEntity,bool> Category)
        {
            pagedAndSorted.Count = GetAllWithIncludeOrNo().Where(Category).Count();
            if (pagedAndSorted.PageItemCount == 0)
                pagedAndSorted.PageItemCount = 9;
            if (pagedAndSorted.SelectPage == 0)
                pagedAndSorted.SelectPage = 1;

            
            var TotalPage = pagedAndSorted.Count / (double)pagedAndSorted.PageItemCount;
        
            TotalPage =Math.Ceiling(TotalPage);
            pagedAndSorted.TotalPage = (short)TotalPage;
            
            return pagedAndSorted;

            
        }

        public virtual List<TEntity> GetAllWithIncludeOrNo()
        {
            return baseRepository.GetAll<TEntity>();
        }

        public virtual List<TEntityDto> GetAll()
        {
            var ListEntity = baseRepository.GetAll<TEntity>().ToList();
           
            return EntityToDto(ListEntity);
        }

        public virtual List<TEntityDto> GetAll(PagedAndSorted pagedAndSorted,Func<TEntity,bool> Category,Func<TEntity,TPrimaryKey> Sort)
        {
            var CustomList = GetAllWithIncludeOrNo().Where(Category).OrderBy(Sort).Skip((pagedAndSorted.PageItemCount * pagedAndSorted.SelectPage) - pagedAndSorted.PageItemCount).Take(pagedAndSorted.PageItemCount).ToList();
            return EntityToDto(CustomList);
        }

       
        public virtual void Update(TEntityDto entityDto)
        {
            baseRepository.Update(DtoToEntity(entityDto));
            unitOfWork.Commit();

        }

        protected TEntityDto EntityToDto(TEntity entity)
        {
            return mapper.Map<TEntityDto>(entity);
        }

        protected TEntity DtoToEntity(TEntityDto entityDto)
        {
            return mapper.Map<TEntity>(entityDto);
        }
        protected List<TEntityDto> EntityToDto(List<TEntity> entity)
        {
            return mapper.Map<List<TEntityDto>>(entity);
        }

        protected List<TEntity> DtoToEntity(List<TEntityDto> entityDto)
        {
            return mapper.Map<List<TEntity>>(entityDto);
        }

        public virtual List<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] AllInclude)
        {
            return baseRepository.AllInclude<TEntity>(AllInclude).ToList();
        }

        public List<TEntityDto> GetAll(Func<TEntity, bool> Category)
        {
            var GetAll = baseRepository.GetAll<TEntity>().Where(Category).ToList();

            return EntityToDto(GetAll);
        }

     
    }
}
