using System.Threading.Tasks;

namespace Cv.Dao.Base.Interface
{
    public interface IInsertDao<T> where T : class
    {
        Task Insert(T entity);
    }
}
