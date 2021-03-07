using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public class CandidatesHistoriesRepository : ICandidatesHistoriesRepository
    {
        private readonly ICandidatesHistoriesDao candidatesHistoriesDao;
        public CandidatesHistoriesRepository(ICandidatesHistoriesDao candidatesHistoriesDao)
        {
            this.candidatesHistoriesDao = candidatesHistoriesDao;
        }

        public async Task Insert(CandidateHistoryModel entity) => await candidatesHistoriesDao.Insert(entity);

        public async Task<bool> Delete(string id) => (await candidatesHistoriesDao.Delete(c => c.CandidateId == id)) > 0;

        public async  Task<PagedListModel<CandidateHistoryModel>> GetBy(string candidateId, int page, PageSizeEnum pageSize) =>
            await candidatesHistoriesDao.GetByFunc(c => c.CandidateId == candidateId, page, pageSize);
    }
}