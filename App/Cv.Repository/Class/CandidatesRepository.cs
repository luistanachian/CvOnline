using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cv.Repository.Class
{
    public sealed class CandidatesRepository : ICandidatesRepository
    {
        private readonly ICandidatesDao candidatesDao;
        public CandidatesRepository(ICandidatesDao candidatesDao)
        {
            this.candidatesDao = candidatesDao;
        }
        public void Insert(CandidateModel candidate)
        {
            candidate.CandidateId = Guid.NewGuid().ToString().Replace("-","");
            candidatesDao.Insert(candidate);
        }
        public void InsertMany(List<CandidateModel> listCandidates)
        { 
            candidatesDao.Insert(listCandidates);
        }
        public bool Replace(CandidateModel candidate)
        {
            var result = candidatesDao.Replace(c => c.CandidateId == candidate.CandidateId, candidate);
            return result > 0;
        }
        public bool Update(CandidateModel candidate, UpdateDefinition<CandidateModel> update)
        {
            var result = candidatesDao.Update(c => c.CandidateId == candidate.CandidateId, update);
            return result > 0;
        }
        public long Update(Expression<Func<CandidateModel, bool>> filter, UpdateDefinition<CandidateModel> update)
        {
            var result = candidatesDao.Update(filter, update, true);
            return result;
        }
        public bool Delete(string id)
        {
            var result = candidatesDao.Delete(c => c.CandidateId == id);
            return result > 0;
        }
        public IList<CandidateModel> GetAllByCompanyId(string companyId)
        {
            var result = candidatesDao.GetListByFunc(c => c.CompanyId == companyId);
            return result.OrderBy(c => c.PersonalData.LastName).ThenBy(c => c.PersonalData.Name).ToList();
        }
    }
}