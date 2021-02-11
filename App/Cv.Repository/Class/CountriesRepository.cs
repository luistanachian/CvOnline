using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ICountriesDao _countriesDao;
        public CountriesRepository(ICountriesDao countriesDao)
        {
            _countriesDao = countriesDao;
        }

        public IList<CountryModel> GetAll()
        {
            var listModel = _countriesDao.GetAll();
            return listModel.OrderBy(c => c.Country).ToList();
        }

        public CountryModel GetById(string code)
        {
            var model = _countriesDao.GetOneByFunc(e => e.CodeCountry == code);
            return model;
        }
    }
}