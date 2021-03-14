using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public class CandidatesHistoriesRepository : ICandidatesHistoriesRepository
    {
        private readonly ICandidatesHistoriesDao candidatesHistoriesDao;
        private readonly FilterDefinitionBuilder<CandidateHistoryModel> fd = Builders<CandidateHistoryModel>.Filter;
        public CandidatesHistoriesRepository(ICandidatesHistoriesDao candidatesHistoriesDao)
        {
            this.candidatesHistoriesDao = candidatesHistoriesDao;
        }

        public async Task Insert(CandidateHistoryModel entity) => await candidatesHistoriesDao.Insert(entity);

        public async Task<bool> Delete(string id) => 
            (await candidatesHistoriesDao.Delete(fd.Eq(c => c.CandidateId, id))) > 0;

        public async Task<bool> Replace(CandidateHistoryModel entity) => 
            (await candidatesHistoriesDao.Replace(fd.Eq(c => c.CandidateId, entity.CandidateId), entity)) > 0;

        public async  Task<CandidateHistoryModel> GetBy(string candidateId) =>
            await candidatesHistoriesDao.GetByFunc(fd.Eq(c => c.CandidateId, candidateId));
    }
}