using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface IStatesBusiness
    {
        IList<StateModel> GetAllByCountry(string codeCountry);
        StateModel GetByIdState(string idState);
    }
}
