using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICountriesDao :
        IGetAllDao<CountryModel>,
        IGetByDao<CountryModel>
    {
    }
}
