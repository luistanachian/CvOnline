using Cv.Models;
using Cv.Models.Enums;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ISearchesHistoriesRepository
    {
        void Insert(SearchHistoryModel entity);
        bool Delete(string id);
        List<SearchHistoryModel> GetBy(string searchId, LinesEnum lines);
    }
}
