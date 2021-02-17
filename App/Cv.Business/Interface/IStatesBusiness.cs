using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface IStatesBusiness
    {
        List<StateModel> GetAllByCountry(string code);
        List<StateModel> GetAllByCountry(int id);
        StateModel GetByIdState(int id);
        StateModel GetByIdState(string code);
    }
}
