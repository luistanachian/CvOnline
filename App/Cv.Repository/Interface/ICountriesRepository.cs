using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICountriesRepository
    {
        List<CountryModel> GetAll();
        CountryModel GetByIso2(string iso2);
        CountryModel GetByIso3(string iso3);
    }
}
