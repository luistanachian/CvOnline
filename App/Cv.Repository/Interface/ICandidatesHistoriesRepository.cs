using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface ICandidatesHistoriesRepository
    {
        Task Insert(CandidateHistoryModel entity);
        Task<bool> Delete(string id);
        Task<PagedListModel<CandidateHistoryModel>> GetBy(string candidateId, int page, PageSizeEnum pageSize);
    }
}