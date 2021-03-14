using Cv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface IStatesRepository
    {
        Task<List<StateModel>> GetAllByCountryId(int id);
        Task<StateModel> GetByIdStateId(int id);
    }
}
