using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{

    public interface ICandidatesRepository
    {
        Task Insert(CandidateModel entity);
        Task<bool> Replace(CandidateModel entity);
        Task<bool> Delete(string companyId, string candidateId);
        Task<CandidateModel> GetBy(string companyId, string candidateId);
        Task<PagedListModel<CandidateModel>> GetBy(CandidateSearch candidateSearch);
        Task<long> Count(CandidateSearch candidateSearch);
    }
}