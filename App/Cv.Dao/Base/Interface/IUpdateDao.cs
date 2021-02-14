using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace Cv.Dao.Base.Interface
{
    public interface IUpdateDao<T> where T : class
    {
        long Replace(Expression<Func<T, bool>> filter, T entity);
        long Update(Expression<Func<T, bool>> filter, UpdateDefinition<T> update, bool many = false);

    }
}
