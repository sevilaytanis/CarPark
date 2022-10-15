﻿using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Repository.Abstract
{
    //genel crud işlemleri burada yapıyoruz
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        GetManyResult<TEntity> AsQueryable();

        Task<GetManyResult<TEntity>> AsQueryableAsync();

        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);

        GetOneResult<TEntity> GetById(string Id);
        Task<GetOneResult<TEntity>> GetByIdAsync(string Id);

        GetOneResult<TEntity> InsertOne(TEntity entity);
        Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity);

        GetOneResult<TEntity> ReplaceOne(TEntity entity, string id);
        Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id);

        GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities);
        Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities);




    }
}
