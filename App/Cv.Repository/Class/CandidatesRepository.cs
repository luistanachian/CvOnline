using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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
            candidatesDao.Insert(candidate);
        }
        public bool Replace(CandidateModel candidate)
        {
            var result = candidatesDao.Replace(c => c.CandidateId == candidate.CandidateId, candidate);
            return result > 0;
        }
        public bool Delete(string id)
        {
            var result = candidatesDao.Delete(c => c.CandidateId == id);
            return result > 0;
        }
        public List<CandidateModel> GetAllByCompanyId(string companyId)
        {
            var result = candidatesDao.GetListByFunc(c => c.CompanyId == companyId);
            return result.OrderBy(c => c.LastName).ThenBy(c => c.Name).ToList();
        }
    }
}