using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface ICountriesBusiness 
    {
        IList<CountryModel> GetAll();
        CountryModel GetById(string code);
    }
}
