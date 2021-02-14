using System;
using System.Linq.Expressions;

namespace Cv.Dao.Base.Interface
{
    public interface IDeleteDao<T> where T : class
    {
        long Delete(Expression<Func<T, bool>> filter);
    }
}
