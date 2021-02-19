using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ISearchesDao :
        IGetByDao<SearchModel>,
        IInsertDao<SearchModel>,
        IReplaceDao<SearchModel>,
        IDeleteDao<SearchModel>
    {
    }
}
