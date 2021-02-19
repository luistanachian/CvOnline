using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public sealed class CountriesRepository : ICountriesRepository
    {
        private readonly ICountriesDao countriesDao;
        public CountriesRepository(ICountriesDao countriesDao)
        {
            this.countriesDao = countriesDao;
        }

        public List<CountryModel> GetAll()
        {
            var listModel = countriesDao.GetAll();
            return listModel.OrderBy(c => c.name).ToList();
        }

        public CountryModel GetById(int id)
        {
            var model = countriesDao.GetOneByFunc(e => e.id == id);
            return model;
        }
    }
}