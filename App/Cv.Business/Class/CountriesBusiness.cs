using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;

namespace Cv.Business.Class
{
    public class CountriesBusiness : ICountriesBusiness
    {

        private readonly ICountriesRepository _countriesRepository;
        public CountriesBusiness(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        public bool Delete(string id)
        {
            return _countriesRepository.Delete(id);
        }

        public IList<CountryModel> GetAll()
        {
            return _countriesRepository.GetAll();
        }

        public CountryModel GetById(string id)
        {
            return _countriesRepository.GetById(id);
        }

        public void Insert(CountryModel entity)
        {
            _countriesRepository.Insert(entity);
        }

        public bool Update(CountryModel entity)
        {
            return _countriesRepository.Update(entity);
        }
    }
}
