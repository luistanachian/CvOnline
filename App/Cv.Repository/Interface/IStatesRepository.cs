using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface IStatesRepository
    {
        IList<StateModel> GetAllByCountry(string codeCountry);
        StateModel GetByIdState(string idState);
    }
}
