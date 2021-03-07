using Cv.Models.Enums;
using Cv.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IGetByDao<T> where T : class
    {
        T GetOneByFunc(Expression<Func<T, bool>> filter);
        long GetCount(Expression<Func<T, bool>> filter);
        Task<long> GetCountAsync(Expression<Func<T, bool>> filter);
        List<T> GetListByFunc(Expression<Func<T, bool>> filter, PageSizeEnum lines);
        Task<PagedListModel<T>> GetListByFuncAsync(Expression<Func<T, bool>> filter, int page, PageSizeEnum pageSize);
    }
}
