using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface IStatesRepository
    {
        List<StateModel> GetAllByCountryId(int id);
        StateModel GetByIdState(int id);
    }
}
