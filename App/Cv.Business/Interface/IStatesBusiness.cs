using Cv.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
