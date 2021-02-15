using Cv.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Repository.Interface
{
    public interface ICandidatesRepository
    {
        void Insert(CandidateModel candidated);
        bool Replace(CandidateModel candidate);
        bool Delete(string id);
        IList<CandidateModel> GetAllByCompanyId(string companyId);
    }
}
