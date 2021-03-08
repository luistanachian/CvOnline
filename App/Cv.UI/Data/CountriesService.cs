using Cv.Business.Interface;
using Cv.Models;
using System.Collections.Generic;
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

        public async Task<List<CountryModel>> GetCountriesAsync() => await countriesBusiness.GetAll();
    }
}