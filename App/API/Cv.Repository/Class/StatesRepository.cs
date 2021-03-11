using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class StatesRepository : IStatesRepository
    {
        private readonly IStatesDao statesDao;
        private readonly FilterDefinitionBuilder<StateModel> fd = Builders<StateModel>.Filter;
        public StatesRepository(IStatesDao statesDao)
        {
            this.statesDao = statesDao;
        }
        public async Task<List<StateModel>> GetAllByCountryId(int id) => 
            (await statesDao.GetAll(fd.Eq(s => s.country_id, id))).OrderBy(x => x.name).ToList();
        public async Task<StateModel> GetByIdStateId(int id) => await statesDao.GetByFunc(fd.Eq(e => e.id, id));
    }
}