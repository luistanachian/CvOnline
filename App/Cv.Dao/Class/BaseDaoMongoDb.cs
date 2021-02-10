using Cv.Dao.Helpers;
using Cv.Dao.Interface;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Cv.Dao.Class
{
    public class BaseDaoMongoDb<TEntity> : IBaseDaoMongoDb<TEntity> where TEntity : class
    {
        public long Delete(FilterDefinition<TEntity> filter)
        {
            var db = HelperMongoDb.DataBase;
            var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);

            var deleteResult = collection.DeleteOne(filter);
            return deleteResult.DeletedCount;
        }

        public IList<TEntity> GetAll()
        {
            var db = HelperMongoDb.DataBase;
            var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
            var list = collection.Find(e => true).ToList();
            return list;
        }

        public IList<TEntity> GetListByFunc(FilterDefinition<TEntity> filter, int? top = null)
        {
            var db = HelperMongoDb.DataBase;
            var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
            var list = collection.Find(filter).Limit(top).ToList();
            return list;
        }

        public TEntity GetOneByFunc(FilterDefinition<TEntity> filter)
        {
            var list = GetListByFunc(filter, 1);
            return list?[0];
        }

        public void Insert(TEntity entity)
        {
            var db = HelperMongoDb.DataBase;
            var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
            collection.InsertOne(entity);
        }

        public long Update(FilterDefinition<TEntity> filter, TEntity entity)
        {
            var db = HelperMongoDb.DataBase;
            var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
            var result = collection.ReplaceOne(filter, entity);
            return result.ModifiedCount;
        }
    }
}
