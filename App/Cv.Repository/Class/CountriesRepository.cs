using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
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

        public List<CountryModel> GetAll() => countriesDao.GetAll().OrderBy(c => c.name).ToList();
        public CountryModel GetById(int id) => countriesDao.GetOneByFunc(e => e.id == id);


        public async Task<PagedListModel<CountryModel>> Get(int page, PageSizeEnum pageSize) =>
            await countriesDao.GetListByFuncAsync(x => true, page, pageSize);
    }
}