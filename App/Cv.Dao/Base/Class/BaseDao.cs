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
        public long Delete(Expression<Func<T, bool>> filter) =>
             ConnectionsMongoDb<T>.GetCollection().DeleteOne(filter).DeletedCount;

        public List<T> GetAll() =>
            ConnectionsMongoDb<T>.GetCollection().Find(e => true).ToList();

        public List<T> GetAll(Expression<Func<T, bool>> filter) =>
            ConnectionsMongoDb<T>.GetCollection().Find(filter).ToList();

        public T GetOneByFunc(Expression<Func<T, bool>> filter) =>
            ConnectionsMongoDb<T>.GetCollection().Find(filter).Limit(1).ToList()?[0];

        public async Task<long> GetCountAsync(Expression<Func<T, bool>> filter) =>
            await ConnectionsMongoDb<T>.GetCollection().CountDocumentsAsync(filter);

        public async Task<PagedListModel<T>> GetListByFuncAsync(Expression<Func<T, bool>> filter, int page, PageSizeEnum pageSize)
        {
            var count = ConnectionsMongoDb<T>.GetCollection().CountDocumentsAsync(filter);
            var data = ConnectionsMongoDb<T>.GetCollection().Find(filter)
                .Skip((page - 1) * (int)pageSize)
                .Limit((int)pageSize)
                .ToListAsync();

            return  new PagedListModel<T> {Count = await count, List = await data, Pages = ((await count + (long)pageSize - 1) / (long)pageSize) } ;
        }



        public void Insert(T entity) =>
            ConnectionsMongoDb<T>.GetCollection().InsertOne(entity);

        public long Replace(Expression<Func<T, bool>> filter, T entity) =>
            ConnectionsMongoDb<T>.GetCollection().ReplaceOne(filter, entity).ModifiedCount;
    }
}