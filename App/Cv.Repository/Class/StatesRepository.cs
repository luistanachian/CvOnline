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

        public List<StateModel> GetAllByCountry(string codeCountry)
        {
            var listModel = statesDao.GetListByFunc(s => s.CodeCountry == codeCountry);
            return listModel.OrderBy(s => s.State).ToList();
        }

        public StateModel GetByIdState(string idState)
        {
            var model = statesDao.GetOneByFunc(e => e.IdState == idState);
            return model;
        }
    }
}