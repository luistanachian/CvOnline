using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
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

        public List<CountryModel> GetAll()
        {
            try
            {
                return countriesRepository.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public CountryModel GetById(int id)
        {
            try
            {
                return countriesRepository.GetById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}