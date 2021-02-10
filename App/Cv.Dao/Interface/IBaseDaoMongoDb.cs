using MongoDB.Driver;
using System.Collections.Generic;

namespace Cv.Dao.Interface
{
    public interface IBaseDaoMongoDb<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetOneByFunc(FilterDefinition<TEntity> filter);
        IList<TEntity> GetListByFunc(FilterDefinition<TEntity> filter, int? top = null);
        void Insert(TEntity entity);
        long Update(FilterDefinition<TEntity> filter, TEntity entity);
        long Delete(FilterDefinition<TEntity> filter);
    }
}
