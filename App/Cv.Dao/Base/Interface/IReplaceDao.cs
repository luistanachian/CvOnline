using System;
using System.Linq.Expressions;

namespace Cv.Dao.Base.Interface
{
    public interface IReplaceDao<T> where T : class
    {
        long Replace(Expression<Func<T, bool>> filter, T entity);

    }
}
