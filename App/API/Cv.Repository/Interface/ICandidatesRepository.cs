using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{

    public interface ICandidatesRepository
    {
        Task Insert(CandidateModel entity);
        Task<bool> Replace(CandidateModel entity);
        Task<bool> Delete(string id);
        Task<CandidateModel> GetBy(string companyId, string candidateId);
        Task<PagedListModel<CandidateModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null);
        Task<long> Count(string companyId, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null);
    }
}
