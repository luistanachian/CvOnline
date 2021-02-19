using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface IUsersDao :
        IGetByDao<UserModel>,
        IInsertDao<UserModel>,
        IReplaceDao<UserModel>,
        IDeleteDao<UserModel>
    {
    }
}
