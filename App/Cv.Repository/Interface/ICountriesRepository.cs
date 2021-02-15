using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICountriesRepository
    {
        List<CountryModel> GetAll();
        CountryModel GetById(string code);
    }
}
