using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICandidatesHistoriesDao :
        IGetAllDao<CandidateHistoryModel>,
        IGetByDao<CandidateHistoryModel>,
        IInsertDao<CandidateHistoryModel>,
        IDeleteDao<CandidateHistoryModel>,
        IReplaceDao<CandidateHistoryModel>
    {
    }
}
