using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public class CandidatesHistoriesRepository : ICandidatesHistoriesRepository
    {
        private readonly ICandidatesHistoriesDao candidatesHistoriesDao;
        public CandidatesHistoriesRepository(ICandidatesHistoriesDao candidatesHistoriesDao)
        {
            this.candidatesHistoriesDao = candidatesHistoriesDao;
        }

        public bool Insert(CandidateHistoryModel entity)
        {
            try
            {
                candidatesHistoriesDao.Insert(entity);
                return true;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                return candidatesHistoriesDao.Delete(c => c.CandidateId == id) > 0;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }
        public List<CandidateHistoryModel> GetBy(string candidateId, int top)
        {
            try
            {
                return candidatesHistoriesDao
                    .GetListByFunc(c => c.CandidateId == candidateId, top)
                    .Select(c => new CandidateHistoryModel
                    {
                        CandidateId = c.CandidateId,
                        History = c.History.OrderByDescending(h => h.Date).ToList()
                    })
                    .ToList();
            }
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }

    }
}