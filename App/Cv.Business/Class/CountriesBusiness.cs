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

                if(result.Object == null || result.Object.Count == 0)
                    result.AddError("No se encontraron paises.");
            }
            catch (Exception)
            {
                result.AddError("Error al consultar los paises.");
            }
            return result;
        }
        public ResultBus<CountryModel> GetById(int id)
        {
            var result = new ResultBus<CountryModel>();
            try
            {
                result.Object = countriesRepository.GetById(id);

                if (result.Object == null)
                    result.AddError("No se encontro el pais.");
            }
            catch (Exception)
            {
                result.AddError("Error al consultar el pais.");
            }
            return result;
        }
    }
}