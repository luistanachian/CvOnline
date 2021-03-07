using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface ICountriesBusiness 
    {
        List<CountryModel> GetAll();
        CountryModel GetById(int id);
        Task<PagedListModel<CountryModel>> Get(int page, PageSizeEnum pageSize);
    }
}
