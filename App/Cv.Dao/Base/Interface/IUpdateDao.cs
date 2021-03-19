using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IUpdateDao<T> where T : class
    {
        Task<long> Update(FilterDefinition<T> filter, UpdateDefinition<T> update);
        Task<long> Replace(FilterDefinition<T> filter, T entity);
    }
}