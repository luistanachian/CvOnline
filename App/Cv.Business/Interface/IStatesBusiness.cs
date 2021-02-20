using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface IStatesBusiness
    {
        ResultBus<List<StateModel>> GetAllByCountryId(int id);
        ResultBus<StateModel> GetByIdStateId(int id);
    }
}
