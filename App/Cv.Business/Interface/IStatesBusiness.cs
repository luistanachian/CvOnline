using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface IStatesBusiness
    {
        List<StateModel> GetAllByCountryId(int id);
        StateModel GetByIdStateId(int id);
    }
}
