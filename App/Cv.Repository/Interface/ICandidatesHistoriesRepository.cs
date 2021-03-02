using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ICandidatesHistoriesRepository
    {
        bool Insert(CandidateHistoryModel candidateHistoryModel);
        bool Delete(string id);
        List<CandidateHistoryModel> GetBy(string candidateId, int top);
    }
}