﻿using Cv.Dao.Interface;
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
            candidate.CandidateId = Guid.NewGuid().ToString();
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
        public IList<CandidateModel> GetAllByCompanyId(string companyId)
        {
            var result = candidatesDao.GetListByFunc(c => c.CompanyId == companyId);
            return result.OrderBy(c => c.PersonalData.LastName).ThenBy(c => c.PersonalData.Name).ToList();
        }
    }
}