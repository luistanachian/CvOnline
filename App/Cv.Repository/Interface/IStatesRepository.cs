using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface IStatesRepository
    {
        List<StateModel> GetAllByCountry(string codeCountry);
        StateModel GetByIdState(string idState);
    }
}
