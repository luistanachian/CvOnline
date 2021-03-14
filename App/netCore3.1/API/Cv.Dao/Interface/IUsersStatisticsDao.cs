using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface IUsersStatisticsDao :
        IGetByDao<UserStatisticsModel>,
        IInsertDao<UserStatisticsModel>,
        IReplaceDao<UserStatisticsModel>,
        IDeleteDao<UserStatisticsModel>
    {
    }
}
