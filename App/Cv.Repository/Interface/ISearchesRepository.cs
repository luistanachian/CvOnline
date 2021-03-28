using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ISearchesRepository
    {
        Task Insert(SearchModel entity);
        Task<bool> Replace(SearchModel entity);
        Task<bool> Delete(string searchId);
        Task<SearchModel> GetBy(string searchId);
        Task<PagedListModel<SearchModel>> GetBy(string clientId, int page, int pageSize);
        Task<long> Count(string clientId);
    }
}
