using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface ICountriesBusiness 
    {
        List<CountryModel> GetAll();
        CountryModel GetByIso2(string iso2);
        CountryModel GetByIso3(string iso2);
    }
}
