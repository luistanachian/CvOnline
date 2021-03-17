using Cv.Dao.Base.Interface;
using Cv.Dao.Configurations;
using Cv.Models.Helpers;
using MongoDB.Driver;
using System.Collections.Generic;
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
        public async Task<List<T>> GetAll()
        {
            var result = await ConnectionsMongoDb<T>.GetCollection().Find(e => true).ToListAsync();
            return result == null || result.Count == 0 ? null : result;
        }
        public async Task<List<T>> GetAll(FilterDefinition<T> filter)
        {
            var result = await ConnectionsMongoDb<T>.GetCollection().Find(filter).ToListAsync();
            return result == null || result.Count == 0 ? null : result;
        }
        public async Task<T> GetByFunc(FilterDefinition<T> filter)
        {
            var result = await ConnectionsMongoDb<T>.GetCollection().Find(filter).Limit(1).ToListAsync();
            return result == null || result.Count == 0 ? null : result[0];
        }

        public async Task<PagedListModel<T>> GetByFunc(FilterDefinition<T> filter, int page, int pageSize)
        {
            var countTask = Count(filter);
            var data = ConnectionsMongoDb<T>.GetCollection().Find(filter)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            var count = await countTask;
            if (count == 0)
                return null;
            else
            {
                return new PagedListModel<T>
                {
                    Count = count,
                    List = await data,
                    Pages = pageSize == 0 ? 1 : ((count + (long)pageSize - 1) / (long)pageSize)
                };
            }
        }
        public async Task<long> Count(FilterDefinition<T> filter) =>
            await ConnectionsMongoDb<T>.GetCollection().CountDocumentsAsync(filter);

        public async Task Insert(T entity) =>
            await ConnectionsMongoDb<T>.GetCollection().InsertOneAsync(entity);

        public async Task<long> Replace(FilterDefinition<T> filter, T entity) =>
            (await ConnectionsMongoDb<T>.GetCollection().ReplaceOneAsync(filter, entity)).ModifiedCount;

        public async Task<long> Delete(FilterDefinition<T> filter) =>
             (await ConnectionsMongoDb<T>.GetCollection().DeleteOneAsync(filter)).DeletedCount;

    }
}