using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ICompaniesRepository
    {
        Task Insert(CompanyModel entity);
        Task<bool> Replace(CompanyModel entity);
        Task<bool> Delete(string id);
        Task<CompanyModel> GetBy(string id);
    }
}
