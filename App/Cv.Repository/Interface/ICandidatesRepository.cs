using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICandidatesRepository
    {
        void Insert(CandidateModel candidated);
        bool Replace(CandidateModel candidate);
        bool Delete(string id);
        List<CandidateModel> GetAllByCompanyId(string companyId);
    }
}
