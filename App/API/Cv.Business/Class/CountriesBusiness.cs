using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using System;
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

        public async Task<List<CountryModel>> GetAll()
        {
            try
            {
                return await countriesRepository.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<CountryModel> GetById(int id)
        {
            try
            {
                return await countriesRepository.GetById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}