using Cv.Models;
using Cv.Models.Helpers;
using Cv.Models.Search;
using System.Net;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface ICandidatesBusiness
    {
        Task<HttpStatusCode> Save(string userId, CandidateModel candidate);
        Task<HttpStatusCode> Delete(string companyId, string candidateId);
        Task<CandidateModel> GetBy(string companyId, string candidateId);
        Task<PagedListModel<CandidateModel>> GetBy(CandidateSearch candidateSearch);
        Task<long> Count(CandidateSearch candidateSearch);
    }
}