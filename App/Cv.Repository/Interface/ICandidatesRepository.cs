using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICandidatesRepository
    {
        bool Insert(CandidateModel candidate);
        bool Replace(CandidateModel candidate);
        bool Delete(string id);
        CandidateModel GetBy(string companyId, string candidateId);
        List<CandidateModel> GetBy(string companyId, int top, string name = null, int? countryId = null, int? stateId = null);
        List<CandidateModel> GetBy(string companyId, int top, List<string> skills, int? countryId = null, int? stateId = null);
        long GetCount(string companyId, string name = null, int? countryId = null, int? stateId = null);
        long GetCount(string companyId, List<string> skills, int? countryId = null, int? stateId = null);
    }
}
