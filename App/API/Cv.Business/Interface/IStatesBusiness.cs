using Cv.Models;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface IStatesBusiness
    {
        Task<List<StateModel>> GetAllByCountryId(int id);
        Task<StateModel> GetByIdStateId(int id);
    }
}
