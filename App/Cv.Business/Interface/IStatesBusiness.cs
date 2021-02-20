using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface IStatesBusiness
    {
        ResultBus<List<StateModel>> GetAllByCountry(int id);
        ResultBus<StateModel> GetByIdState(int id);
    }
}
