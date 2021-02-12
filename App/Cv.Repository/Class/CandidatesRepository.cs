﻿using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public class CandidatesRepository : ICandidatesRepository
    {
        private readonly ICandidatesDao candidatesDao;
        public CandidatesRepository(ICandidatesDao candidatesDao)
        {
            this.candidatesDao = candidatesDao;
        }
        public void Insert(CandidateModel candidated)
        {
            candidatesDao.Insert(candidated);
        }
        public bool Update(CandidateModel candidate)
        {
            var result = candidatesDao.Update(c => c.Id == candidate.Id, candidate);
            return result > 0;
        }
        public bool Delete(string id)
        {
            var result = candidatesDao.Delete(c => c.Id == id);
            return result > 0;
        }
        public IList<CandidateModel> GetAllByCompanyId(string companyId)
        {
            var result = candidatesDao.GetListByFunc(c => c.CompanyId == companyId);
            return result.OrderBy(c => c.LastName).ThenBy(c => c.Name).ToList();
        }
    }
}