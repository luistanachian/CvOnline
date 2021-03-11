using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface ICandidatesBusiness
    {
        Task<bool> Insert(CandidateModel candidate);
        Task<bool> Replace(CandidateModel candidate, string userID);
        Task<bool> Delete(string id);
        Task<CandidateModel> GetBy(string companyId, string candidateId);
        Task<PagedListModel<CandidateModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null);
        Task<long> Count(string companyId, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null);
    }
}