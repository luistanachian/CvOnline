using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public class SearchesHistoriesRepository : ISearchesHistoriesRepository
    {
        private readonly ISearchesHistoriesDao searchesHistoriesDao;
        private readonly FilterDefinitionBuilder<SearchHistoryModel> fd = Builders<SearchHistoryModel>.Filter;
        public SearchesHistoriesRepository(ISearchesHistoriesDao searchesHistoriesDao)
        {
            this.searchesHistoriesDao = searchesHistoriesDao;
        }

        public async Task Insert(SearchHistoryModel entity) => await searchesHistoriesDao.Insert(entity); 

        public async Task<bool> Delete(string id) => (await searchesHistoriesDao.Delete(fd.Eq(c => c.SearchId, id))) > 0;

        public async Task<PagedListModel<SearchHistoryModel>> GetBy(string searchId, int page, int pageSize) => 
            await searchesHistoriesDao.GetByFunc(fd.Eq(c => c.SearchId, searchId), page, pageSize);
    }
}