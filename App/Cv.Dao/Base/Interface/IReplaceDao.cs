using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IReplaceDao<T> where T : class
    {
        Task<long> Replace(Expression<Func<T, bool>> filter, T entity);
    }
}
