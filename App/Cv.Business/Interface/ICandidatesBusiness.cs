using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface ICandidatesBusiness
    {
        Task<bool> Insert(CandidateModel candidate);
        Task<bool> Replace(CandidateModel candidate);
        Task<bool> Delete(string companyId);
        Task<PagedListModel<CandidateModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, int countryId, int stateId, StatusCandiateEnum? status = null);
    }
}
