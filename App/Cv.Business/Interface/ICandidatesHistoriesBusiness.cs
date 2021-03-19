using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface ICandidatesHistoriesBusiness
    {
        Task<bool> Add(string candidateId, EventItem eventItem);
        Task<bool> Delete(string id);
        Task<CandidateHistoryModel> GetBy(string candidateId);
    }
}
