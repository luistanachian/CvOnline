using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ICompaniesStatisticsRepository
    {
        Task Insert(CompanyStatisticsModel entity);
        Task<bool> Replace(CompanyStatisticsModel entity);
        Task<bool> Delete(string companyId);
        Task<CompanyStatisticsModel> GetBy(string companyId);
    }
}