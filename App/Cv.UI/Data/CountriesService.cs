using Cv.Business.Interface;
using Cv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.UI.Data
{
    public class CountriesService
    {
        ICountriesBusiness countriesBusiness;
        public CountriesService(ICountriesBusiness countriesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
        }


        public Task<CountryModel[]> GetCountriesAsync()
        {
            return Task.FromResult(countriesBusiness.GetAll().Object.ToArray());
        }
    }
}
