using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;

namespace Cv.Business.Class
{
    public sealed class CountriesBusiness : ICountriesBusiness
    {

        private readonly ICountriesRepository countriesRepository;
        public CountriesBusiness(ICountriesRepository countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public List<CountryModel> GetAll() => countriesRepository.GetAll();
        public CountryModel GetByIso2(string iso2) => countriesRepository.GetByIso2(iso2);
        public CountryModel GetByIso3(string iso3) => countriesRepository.GetByIso3(iso3);
    }
}
