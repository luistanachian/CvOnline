using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Dao.Interface
{
    public interface IBaseDaoMongoDb<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetOneByFunc(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetListByFunc(Expression<Func<TEntity, bool>> filter, int? top = null);
        void Insert(TEntity entity);
        long Update(Expression<Func<TEntity, bool>> filter, TEntity entity);
        long Delete(Expression<Func<TEntity, bool>> filter);
    }
}
