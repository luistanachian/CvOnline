using System.Collections.Generic;

namespace Cv.Dao.Base.Interface
{
    public interface IInsertDao<T> where T : class
    {
        void Insert(T entity);
        void Insert(List<T> listEntity);
    }
}
