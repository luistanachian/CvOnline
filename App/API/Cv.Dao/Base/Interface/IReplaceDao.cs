using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IReplaceDao<T> where T : class
    {
        Task<long> Replace(FilterDefinition<T> filter, T entity);
    }
}
