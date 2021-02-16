using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface IStatesRepository
    {
        List<StateModel> GetAllByCountry(string code);
        List<StateModel> GetAllByCountry(int id);
        StateModel GetByIdState(int id);
        StateModel GetByIdState(string code);
    }
}
