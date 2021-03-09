using Cv.Models;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface ICountriesBusiness 
    {
        Task<List<ComboResponse>> GetAll();
        Task<CountryModel> GetById(int id);
    }
}