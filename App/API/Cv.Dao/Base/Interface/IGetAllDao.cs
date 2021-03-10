using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IGetAllDao<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(FilterDefinition<T> filter);
    }
}