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
        void InsertMany(List<CandidateModel> listCandidates);
        bool Replace(CandidateModel candidate);
        bool Update(CandidateModel candidate, UpdateDefinition<CandidateModel> update);
        long Update(Expression<Func<CandidateModel, bool>> filter, UpdateDefinition<CandidateModel> update);
        bool Delete(string id);
        IList<CandidateModel> GetAllByCompanyId(string companyId);
    }
}
