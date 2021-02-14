using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Dao.Base.Interface
{
    public interface IGetByDao<T> where T : class
    {
        T GetOneByFunc(Expression<Func<T, bool>> filter);
        IList<T> GetListByFunc(Expression<Func<T, bool>> filter, int? top = null);
    }
}
