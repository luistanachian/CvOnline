using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class CountriesRepository : ICountriesRepository
    {
        private readonly ICountriesDao countriesDao;
        private readonly FilterDefinitionBuilder<CountryModel> fd = Builders<CountryModel>.Filter;
        public CountriesRepository(ICountriesDao countriesDao)
        {
            this.countriesDao = countriesDao;
        }

        public async Task<List<CountryModel>> GetAll() =>
            await countriesDao.GetAll();

        public async Task<CountryModel> GetById(int id) => 
            await countriesDao.GetByFunc(fd.Eq(e => e.id, id));
    }
}