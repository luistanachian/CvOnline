using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ICandidatesHistoriesRepository
    {
        Task Insert(CandidateHistoryModel entity);
        Task<bool> Delete(string id);
        Task<bool> Replace(CandidateHistoryModel entity);
        Task<CandidateHistoryModel> GetBy(string candidateId);
    }
}