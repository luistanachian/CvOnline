using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ISearchesHistoriesDao :
        IGetByDao<SearchHistoryModel>,
        IInsertDao<SearchHistoryModel>,
        IDeleteDao<SearchHistoryModel>
    {
    }
}
