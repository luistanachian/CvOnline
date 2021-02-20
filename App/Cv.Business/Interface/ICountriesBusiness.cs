using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface ICountriesBusiness 
    {
        ResultBus<List<CountryModel>> GetAll();
        ResultBus<CountryModel> GetById(int id);
    }
}
