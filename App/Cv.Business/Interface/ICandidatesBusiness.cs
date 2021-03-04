using Cv.Models;
using Cv.Models.Enums;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface ICandidatesBusiness
    {
        bool Insert(CandidateModel candidated);
        bool Replace(CandidateModel candidate);
        bool Delete(string id);
        List<CandidateModel> GetBy(string companyId,
            LinesEnum lines,
            string name = null,
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null);
    }
}
