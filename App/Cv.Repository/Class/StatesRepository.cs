using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public sealed class StatesRepository : IStatesRepository
    {
        private readonly IStatesDao statesDao;
        public StatesRepository(IStatesDao statesDao)
        {
            this.statesDao = statesDao;
        }
        public List<StateModel> GetAllByCountryId(int id) => 
            statesDao.GetListByFunc(s => s.country_id == id).OrderBy(s => s.name).ToList();
        public StateModel GetByIdStateId(int id) => statesDao.GetOneByFunc(e => e.id == id);
    }
}