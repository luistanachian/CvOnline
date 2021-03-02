using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ISearchesHistoriesRepository
    {
        bool Insert(SearchHistoryModel entity);
        bool Delete(string id);
        List<SearchHistoryModel> GetBy(string searchId, int top);
    }
}
