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
        IUpdateDao<T>,
        IDeleteDao<T>
        where T : class
    {
        public async Task<List<T>> GetAll() => 
            await ConnectionsMongoDb<T>.GetCollection().Find(e => true).ToListAsync();

        public async Task<List<T>> GetAll(FilterDefinition<T> filter) =>
            await ConnectionsMongoDb<T>.GetCollection().Find(filter).ToListAsync();

        public async Task<T> GetByFunc(FilterDefinition<T> filter) => 
                await ConnectionsMongoDb<T>.GetCollection().Find(filter).FirstAsync();

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

        public async Task<long> Update(FilterDefinition<T> filter, UpdateDefinition<T> update) =>
            (await ConnectionsMongoDb<T>.GetCollection().UpdateOneAsync(filter, update)).ModifiedCount;

        public async Task<long> Replace(FilterDefinition<T> filter, T entity) =>
            (await ConnectionsMongoDb<T>.GetCollection().ReplaceOneAsync(filter, entity)).ModifiedCount;

        public async Task<long> Delete(FilterDefinition<T> filter) =>
             (await ConnectionsMongoDb<T>.GetCollection().DeleteOneAsync(filter)).DeletedCount;


        

    }
}