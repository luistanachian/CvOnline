using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICompaniesStatisticsDao :
        IGetByDao<CompanyStatisticsModel>,
        IInsertDao<CompanyStatisticsModel>,
        IReplaceDao<CompanyStatisticsModel>,
        IDeleteDao<CompanyStatisticsModel>
    {
    }
}
