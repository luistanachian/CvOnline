using Cv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ICountriesRepository
    {
        Task<List<CountryModel>> GetAll();
        Task<CountryModel> GetById(int id);
    }
}
