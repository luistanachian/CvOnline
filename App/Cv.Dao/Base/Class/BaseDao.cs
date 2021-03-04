using Cv.Dao.Base.Interface;
using Cv.Dao.Configurations;
using Cv.Models.Enums;
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

        public List<T> GetListByFunc(Expression<Func<T, bool>> filter, LinesEnum lines) =>
            ConnectionsMongoDb<T>.GetCollection().Find(filter).Limit((int)lines).ToList();

        public long GetCount(Expression<Func<T, bool>> filter) =>
            ConnectionsMongoDb<T>.GetCollection().Find(filter).CountDocuments();

        public T GetOneByFunc(Expression<Func<T, bool>> filter) =>
            ConnectionsMongoDb<T>.GetCollection().Find(filter).Limit(1).ToList()?[0];

        public void Insert(T entity) =>
            ConnectionsMongoDb<T>.GetCollection().InsertOne(entity);

        public long Replace(Expression<Func<T, bool>> filter, T entity) =>
            ConnectionsMongoDb<T>.GetCollection().ReplaceOne(filter, entity).ModifiedCount;
    }
}