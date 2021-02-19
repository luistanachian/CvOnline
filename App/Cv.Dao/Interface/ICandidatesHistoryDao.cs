using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICandidatesHistoryDao :
        IGetByDao<CandidateHistoryModel>,
        IInsertDao<CandidateHistoryModel>,
        IDeleteDao<CandidateHistoryModel>
    {
    }
}
