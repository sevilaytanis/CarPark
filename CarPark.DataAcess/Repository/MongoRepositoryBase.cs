using CarPark.Core.Models;
using CarPark.Core.Repository.Abstract;
using CarPark.Core.Settings;
using CarPark.DataAcess.Context;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DataAcess.Repository
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly MongoDBContext _context;
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context = new MongoDBContext(settings);
            _collection = _context.GetCollection<TEntity>();
        }

        public GetManyResult<TEntity> AsQueryable()
        {
            var result = new GetManyResult<TEntity>();

            try
            {
                var data = _collection.AsQueryable().ToList();
                if (data != null)
                    result.EntityList = data;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.EntityList = null;
            }

            return result;

        }

        public async Task<GetManyResult<TEntity>> AsQueryableAsync()
        {
            var result = new GetManyResult<TEntity>();

            try
            {
                var data = await _collection.AsQueryable().ToListAsync();
                if (data != null)
                    result.EntityList = data;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.EntityList = null;
            }

            return result;

        }

        public GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();

            try
            {
                var data = _collection.Find(filter).ToList();
                if (data != null)
                    result.EntityList = data;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.EntityList = null;
            }

            return result;
        }

        public async Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();

            try
            {
                var data = await _collection.Find(filter).ToListAsync();
                if (data != null)
                    result.EntityList = data;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.EntityList = null;
            }

            return result;
        }

        public GetOneResult<TEntity> GetById(string Id)
        {
            var result = new GetOneResult<TEntity>();

            try
            {
                var objectId = ObjectId.Parse(Id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);

                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }

        public async Task<GetOneResult<TEntity>> GetByIdAsync(string Id)
        {
            var result = new GetOneResult<TEntity>();

            try
            {
                var objectId = ObjectId.Parse(Id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);

                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }

        public async Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities)
        {
            var result = new GetManyResult<TEntity>();

            try
            {
                await _collection.InsertManyAsync(entities);

                result.EntityList = entities;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.EntityList = null;
            }

            return result;
        }

        public GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities)
        {
            var result = new GetManyResult<TEntity>();

            try
            {
                _collection.InsertMany(entities);

                result.EntityList = entities;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.EntityList = null;
            }

            return result;
        }

        public GetOneResult<TEntity> InsertOne(TEntity entity)
        {
            var result = new GetOneResult<TEntity>();

            try
            {

                _collection.InsertOne(entity);

                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }

        public async Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity)
        {
            var result = new GetOneResult<TEntity>();

            try
            {

                await _collection.InsertOneAsync(entity);

                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }

        public GetOneResult<TEntity> ReplaceOne(TEntity entity, string id)
        {
            var result = new GetOneResult<TEntity>();

            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);

                var updatedItem = _collection.ReplaceOne(filter, entity);
                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }

        public async Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id)
        {

            var result = new GetOneResult<TEntity>();

            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);

                var updatedItem = await _collection.ReplaceOneAsync(filter, entity);
                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"AsQueryable {e.Message} ";
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }
    }
}

