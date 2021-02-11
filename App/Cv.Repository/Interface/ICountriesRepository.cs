using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICountriesRepository
    {
        IList<CountryModel> GetAll();
        CountryModel GetById(string code);
    }
}
