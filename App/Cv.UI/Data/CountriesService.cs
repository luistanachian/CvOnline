using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Threading.Tasks;

namespace Cv.UI.Data
{
    public class CountriesService
    {
        ICountriesBusiness countriesBusiness;
        public CountriesService(ICountriesBusiness countriesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
        }


        public async Task<PagedListModel<CountryModel>> GetCountriesAsync(int page, PageSizeEnum pageSize)
        {
            return await countriesBusiness.Get(page, pageSize);
        }
    }
}
