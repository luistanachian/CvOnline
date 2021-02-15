using Cv.Dao.Base.Interface;
using Cv.Dao.Configurations;
using Cv.Dao.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        public long Delete(Expression<Func<T, bool>> filter)
        {
            var result = ConnectionsMongoDb<T>.GetCollection().DeleteOne(filter);
            return result.DeletedCount;
        }

        public IList<T> GetAll()
        {
            var result = ConnectionsMongoDb<T>.GetCollection().Find(e => true).ToList();
            return result;
        }

        public IList<T> GetListByFunc(Expression<Func<T, bool>> filter, int? top = null)
        {
            var result = ConnectionsMongoDb<T>.GetCollection().Find(filter).Limit(top).ToList();
            return result;
        }

        public T GetOneByFunc(Expression<Func<T, bool>> filter)
        {
            var result = GetListByFunc(filter, 1);
            return result?[0];
        }

        public void Insert(T entity)
        {
            ConnectionsMongoDb<T>.GetCollection().InsertOne(entity);
        }
        public void Insert(List<T> listEntity)
        {
            ConnectionsMongoDb<T>.GetCollection().InsertMany(listEntity);
        }

        public long Replace(Expression<Func<T, bool>> filter, T entity)
        {
            var result = ConnectionsMongoDb<T>.GetCollection().ReplaceOne(filter, entity);
            return result.ModifiedCount;
        }
        public long Update(Expression<Func<T, bool>> filter, UpdateDefinition<T> update, bool many = false)
        {
            var collection = ConnectionsMongoDb<T>.GetCollection();
            var result = many ? collection.UpdateMany(filter, update) : collection.UpdateOne(filter, update);
            return result.ModifiedCount;
        }
    }
}
