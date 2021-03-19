using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICompaniesDao :
        IGetByDao<CompanyModel>,
        IInsertDao<CompanyModel>,
        IUpdateDao<CompanyModel>,
        IDeleteDao<CompanyModel>
    {
    }
}
