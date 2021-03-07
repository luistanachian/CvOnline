using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Repository.Interface;
using MongoDB.Driver;
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

        public void Insert(CandidateHistoryModel entity) => candidatesHistoriesDao.Insert(entity);

        public bool Delete(string id) => candidatesHistoriesDao.Delete(c => c.CandidateId == id) > 0; 

        public List<CandidateHistoryModel> GetBy(string candidateId, PageSizeEnum lines) =>
            candidatesHistoriesDao
                    .GetListByFunc(c => c.CandidateId == candidateId, lines)
                    .Select(c => new CandidateHistoryModel
                    {
                        CandidateId = c.CandidateId,
                        History = c.History.OrderByDescending(h => h.Date).ToList()
                    })
                    .ToList();
    }
}