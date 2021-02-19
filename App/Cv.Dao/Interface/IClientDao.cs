using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface IClientDao :
        IGetByDao<ClientModel>,
        IInsertDao<ClientModel>,
        IReplaceDao<ClientModel>,
        IDeleteDao<ClientModel>
    {
    }
}
