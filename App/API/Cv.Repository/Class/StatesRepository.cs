using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class StatesRepository : IStatesRepository
    {
        private readonly IStatesDao statesDao;
        public StatesRepository(IStatesDao statesDao)
        {
            this.statesDao = statesDao;
        }
        public async Task<List<ComboResponse>> GetAllByCountryId(int id) => 
            (await statesDao.GetAll(s => s.country_id == id))
            .Select(x => new ComboResponse { id = x.id, value = x.name})
            .OrderBy(x => x.value)
            .ToList();
        public async Task<StateModel> GetByIdStateId(int id) => await statesDao.GetByFunc(e => e.id == id);
    }
}