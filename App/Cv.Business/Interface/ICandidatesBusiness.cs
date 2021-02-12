using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface ICandidatesBusiness
    {
        void Insert(CandidateModel candidated);
        void InsertMany(List<CandidateModel> listCandidate);
        bool Update(CandidateModel candidate);
        bool Delete(string id);
        IList<CandidateModel> GetAllByCompanyId(string companyId);
    }
}
