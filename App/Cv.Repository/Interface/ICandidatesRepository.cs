using Cv.Models;
using Cv.Models.Enums;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICandidatesRepository
    {
        void Insert(CandidateModel entity);
        bool Replace(CandidateModel entity);
        bool Delete(string id);
        CandidateModel GetBy(string companyId, string candidateId);
        List<CandidateModel> GetBy(string companyId, PageSizeEnum lines, string name = null, StatusCandiateEnum? status = null, int? countryId = null, int? stateId = null);
        List<CandidateModel> GetBy(string companyId, PageSizeEnum lines, List<string> skills, StatusCandiateEnum? status = null, int? countryId = null, int? stateId = null);
        long GetCount(string companyId, string name = null, StatusCandiateEnum? status = null, int? countryId = null, int? stateId = null);
        long GetCount(string companyId, List<string> skills, StatusCandiateEnum? status = null, int? countryId = null, int? stateId = null);
    }
}
