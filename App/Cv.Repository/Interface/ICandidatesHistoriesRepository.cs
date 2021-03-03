using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICandidatesHistoriesRepository
    {
        void Insert(CandidateHistoryModel entity);
        bool Delete(string id);
        List<CandidateHistoryModel> GetBy(string candidateId, int top);
    }
}