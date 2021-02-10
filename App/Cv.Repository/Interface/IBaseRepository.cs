using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Repository.Interface
{
    public interface IBaseRepository<TEntity, TId>
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
