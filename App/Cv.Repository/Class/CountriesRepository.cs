using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;

namespace Cv.Repository.Class
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ICountriesDao _countriesDao;
        public CountriesRepository(ICountriesDao countriesDao)
        {
            _countriesDao = countriesDao;
        }

        public bool Delete(string id)
        {
            var deletedRows = _countriesDao.Delete(e => e.Code == id);
            return deletedRows > 0;
        }

        public IList<CountryModel> GetAll()
        {
            var listModel = _countriesDao.GetAll();
            return listModel;
        }

        public CountryModel GetById(string id)
        {
            var model = _countriesDao.GetOneByFunc(e => e.Code == id);
            return model;
        }

        public void Insert(CountryModel entity)
        {
            _countriesDao.Insert(entity);
        }

        public bool Update(CountryModel entity)
        {
            var updateRows = _countriesDao.Update(e => e.Code == entity.Code, entity);
            return updateRows > 0;
        }
    }
}
