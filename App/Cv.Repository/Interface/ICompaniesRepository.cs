using Cv.Models;

namespace Cv.Repository.Interface
{
    public interface ICompaniesRepository
    {
        void Insert(CompanyModel entity);
        bool Replace(CompanyModel entity);
        bool Delete(string id);
        CompanyModel GetBy(string id);
    }
}
