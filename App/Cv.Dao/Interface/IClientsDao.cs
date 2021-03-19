using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface IClientsDao :
        IGetByDao<ClientModel>,
        IInsertDao<ClientModel>,
        IUpdateDao<ClientModel>,
        IDeleteDao<ClientModel>
    {
    }
}
