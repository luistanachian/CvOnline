using Cv.Dao.Base.Interface;
using Cv.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Dao.Interface
{
    public interface ICandidateHistoryDao :
        IGetByDao<CandidateHistoryModel>,
        IInsertDao<CandidateHistoryModel>,
        IDeleteDao<CandidateHistoryModel>
    {
    }
}
