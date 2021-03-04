using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface ICountriesBusiness 
    {
        List<CountryModel> GetAll();
        CountryModel GetById(int id);
    }
}
