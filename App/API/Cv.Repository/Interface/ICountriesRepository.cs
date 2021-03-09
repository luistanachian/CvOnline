using Cv.Models;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ICountriesRepository
    {
        Task<List<ComboResponse>> GetAll();
        Task<CountryModel> GetById(int id);
    }
}
