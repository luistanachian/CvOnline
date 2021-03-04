using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface IStatesDao :
        IGetAllDao<StateModel>,
        IGetByDao<StateModel>
    {
    }
}
