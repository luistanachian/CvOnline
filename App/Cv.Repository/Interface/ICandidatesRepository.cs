using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICandidatesRepository
    {
        void Insert(CandidateModel candidated);
        bool Update(CandidateModel candidate);
        bool Delete(string id);
        IList<CandidateModel> GetAllByCompanyId(string companyId);
    }
}
