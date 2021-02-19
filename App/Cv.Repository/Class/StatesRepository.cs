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
        public List<StateModel> GetAllByCountryId(int id)
        {
            var listModel = statesDao.GetListByFunc(s => s.country_id == id);
            return listModel.OrderBy(s => s.name).ToList();
        }

        public StateModel GetByIdState(int id)
        {
            var model = statesDao.GetOneByFunc(e => e.id == id);
            return model;
        }
    }
}