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

        public ResultBus<List<CountryModel>> GetAll()
        {
            var result = new ResultBus<List<CountryModel>>();
            try
            {
                result.Object = countriesRepository.GetAll();
            }
            catch (Exception)
            {
                result.AddError("Error al consultar los estados.");
            }
            return result;
        }
        public ResultBus<CountryModel> GetById(int id)
        {
            var result = new ResultBus<CountryModel>();
            try
            {
                result.Object = countriesRepository.GetById(id);
            }
            catch (Exception)
            {
                result.AddError("Error al consultar los estados.");
            }
            return result;
        }
    }
}