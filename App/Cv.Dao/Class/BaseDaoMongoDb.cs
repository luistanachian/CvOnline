﻿using Cv.Dao.Configurations;
using Cv.Dao.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Dao.Class
{
    public class BaseDaoMongoDb<T> : IBaseDaoMongoDb<T> where T : class
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
        public void InsertMany(List<T> listEntity)
        {
            ConnectionsMongoDb<T>.GetCollection().InsertMany(listEntity);
        }

        public long Update(Expression<Func<T, bool>> filter, T entity)
        {
            var result = ConnectionsMongoDb<T>.GetCollection().ReplaceOne(filter, entity);
            return result.ModifiedCount;
        }
    }
}
