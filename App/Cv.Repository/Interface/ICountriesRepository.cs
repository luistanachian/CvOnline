using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ICountriesRepository
    {
        List<CountryModel> GetAll();
        CountryModel GetById(int id);
        Task<PagedListModel<CountryModel>> Get(int page, PageSizeEnum pageSize);
    }
}
