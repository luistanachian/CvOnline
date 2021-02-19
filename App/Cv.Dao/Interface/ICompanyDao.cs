using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICompanyDao :
        IGetByDao<CompanyModel>,
        IInsertDao<CompanyModel>,
        IReplaceDao<CompanyModel>,
        IDeleteDao<CompanyModel>
    {
    }
}
