using Cv.Dao.Base.Interface;
using Cv.Dao.Configurations;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Class
{
    public abstract class BaseDao<T> :
        IGetAllDao<T>,
        IGetByDao<T>,
        IInsertDao<T>,
        IReplaceDao<T>,
        IDeleteDao<T>
        where T : class
    {
        public async Task<long> Delete(Expression<Func<T, bool>> filter) =>
             (await ConnectionsMongoDb<T>.GetCollection().DeleteOneAsync(filter)).DeletedCount;

        public async Task<List<T>> GetAll() =>
            await ConnectionsMongoDb<T>.GetCollection().Find(e => true).ToListAsync();

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter) =>
            await ConnectionsMongoDb<T>.GetCollection().Find(filter).ToListAsync();

        public async Task<T> GetByFunc(Expression<Func<T, bool>> filter) => 
            (await ConnectionsMongoDb<T>.GetCollection().Find(filter).Limit(1).ToListAsync())?[0];

        public async Task<PagedListModel<T>> GetByFunc(Expression<Func<T, bool>> filter, int page, PageSizeEnum pageSize)
        {
            var count = ConnectionsMongoDb<T>.GetCollection().CountDocumentsAsync(filter);
            var data = ConnectionsMongoDb<T>.GetCollection().Find(filter)
                .Skip((page - 1) * (int)pageSize)
                .Limit((int)pageSize)
                .ToListAsync();

            return new PagedListModel<T>
            {
                Count = await count,
                List = await data,
                Pages = pageSize == PageSizeEnum.All ? 1 : ((await count + (long)pageSize - 1) / (long)pageSize)
            };
        }
        public async Task<long> Count(Expression<Func<T, bool>> filter) =>
            await ConnectionsMongoDb<T>.GetCollection().CountDocumentsAsync(filter);

        public async Task Insert(T entity) =>
            await ConnectionsMongoDb<T>.GetCollection().InsertOneAsync(entity);

        public async Task<long> Replace(Expression<Func<T, bool>> filter, T entity) =>
            (await ConnectionsMongoDb<T>.GetCollection().ReplaceOneAsync(filter, entity)).ModifiedCount;
    }
}