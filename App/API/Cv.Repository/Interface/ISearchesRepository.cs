using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ISearchesRepository
    {
        Task Insert(SearchModel entity);
        Task<bool> Replace(SearchModel entity);
        Task<bool> Delete(string searchId);
        Task<SearchModel> GetBy(string searchId);
        Task<PagedListModel<SearchModel>> GetBy(string clientId, int page, PageSizeEnum pageSize);
        Task<long> Count(string clientId);
    }
}
