using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface IBaseBusiness<TEntity, TId>
        where TEntity : class
        where TId : notnull
    {
        IList<TEntity> GetAll();
        TEntity GetById(TId id);
        void Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TId id);
    }
}
