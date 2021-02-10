using Cv.Dao.Helpers;
using Cv.Dao.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Dao.Class
{
    public class BaseDaoMongoDb<TEntity> : IBaseDaoMongoDb<TEntity> where TEntity : class
    {
        public long Delete(Expression<Func<TEntity, bool>> filter)
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

        public IList<TEntity> GetListByFunc(Expression<Func<TEntity, bool>> filter, int? top = null)
        {
            var db = HelperMongoDb.DataBase;
            var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
            var list = collection.Find(filter).Limit(top).ToList();
            return list;
        }

        public TEntity GetOneByFunc(Expression<Func<TEntity, bool>> filter)
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

        public long Update(Expression<Func<TEntity, bool>> filter, TEntity entity)
        {
            var db = HelperMongoDb.DataBase;
            var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
            var result = collection.ReplaceOne(filter, entity);
            return result.ModifiedCount;
        }
    }
}
