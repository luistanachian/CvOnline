using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ISearchesDao :
        IGetByDao<SearchModel>,
        IInsertDao<SearchModel>,
        IUpdateDao<SearchModel>,
        IDeleteDao<SearchModel>
    {
    }
}
