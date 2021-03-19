using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICandidatesDao :
        IGetByDao<CandidateModel>,
        IInsertDao<CandidateModel>,
        IUpdateDao<CandidateModel>,
        IDeleteDao<CandidateModel>
    {
    }
}
