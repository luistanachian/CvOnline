using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Business.Class
{
    public sealed class CountriesBusiness : ICountriesBusiness
    {

        private readonly ICountriesRepository countriesRepository;
        public CountriesBusiness(ICountriesRepository countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task<List<CountryModel>> GetAll() => 
            await countriesRepository.GetAll();
        public async Task<CountryModel> GetById(int id) => 
            await countriesRepository.GetById(id);
    }
}