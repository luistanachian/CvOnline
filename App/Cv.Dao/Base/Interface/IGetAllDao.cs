using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Dao.Base.Interface
{
    public interface IGetAllDao<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter);
    }
}