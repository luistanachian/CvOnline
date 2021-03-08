using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IDeleteDao<T> where T : class
    {
        Task<long> Delete(Expression<Func<T, bool>> filter);
    }
}
