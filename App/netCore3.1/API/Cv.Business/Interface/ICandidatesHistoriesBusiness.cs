using Cv.Models;
using Cv.Models.Items;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface ICandidatesHistoriesBusiness
    {
        Task<bool> Add(string candidateId, EventItem eventItem);
        Task<bool> Insert(string candidateID, EventItem eventItem);
        Task<bool> Delete(string id);
        Task<CandidateHistoryModel> GetBy(string candidateId);
    }
}
