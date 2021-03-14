using Cv.Models.Enums;
using Cv.Models.Helpers;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IGetByDao<T> where T : class
    {
        Task<T> GetByFunc(FilterDefinition<T> filter);
        Task<long> Count(FilterDefinition<T> filter);
        Task<PagedListModel<T>> GetByFunc(FilterDefinition<T> filter, int page, PageSizeEnum pageSize);
    }
}
