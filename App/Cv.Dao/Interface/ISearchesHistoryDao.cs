using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ISearchesHistoryDao :
        IGetByDao<SearchHistoryModel>,
        IInsertDao<SearchHistoryModel>,
        IDeleteDao<SearchHistoryModel>
    {
    }
}
