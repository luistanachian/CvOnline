using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IGetAllDao<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter);
    }
}