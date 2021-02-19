using Cv.Dao.Base.Interface;
using Cv.Models.Models;

namespace Cv.Dao.Interface
{
    public interface ICandidateHistoryDao :
        IGetByDao<CandidateHistoryModel>,
        IInsertDao<CandidateHistoryModel>,
        IDeleteDao<CandidateHistoryModel>
    {
    }
}
