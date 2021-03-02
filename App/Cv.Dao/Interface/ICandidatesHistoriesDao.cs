using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICandidatesHistoriesDao :
        IGetByDao<CandidateHistoryModel>,
        IInsertDao<CandidateHistoryModel>,
        IDeleteDao<CandidateHistoryModel>
    {
    }
}
