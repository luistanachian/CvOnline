using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IDeleteDao<T> where T : class
    {
        Task<long> Delete(FilterDefinition<T> filter);
    }
}
