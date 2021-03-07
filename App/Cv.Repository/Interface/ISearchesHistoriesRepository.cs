using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ISearchesHistoriesRepository
    {
        Task Insert(SearchHistoryModel entity);
        Task<bool> Delete(string id);
        Task<PagedListModel<SearchHistoryModel>> GetBy(string searchId, int page, PageSizeEnum pageSize);
    }
}
