using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class CountriesRepository : ICountriesRepository
    {
        private readonly ICountriesDao countriesDao;
        public CountriesRepository(ICountriesDao countriesDao)
        {
            this.countriesDao = countriesDao;
        }

        public async Task<List<CountryModel>> GetAll() =>
            (await countriesDao.GetAll()).OrderBy(c => c.name).ToList();

        public async Task<CountryModel> GetById(int id) => await countriesDao.GetByFunc(e => e.id == id);
    }
}