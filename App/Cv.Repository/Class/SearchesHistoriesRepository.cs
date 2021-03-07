using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public class SearchesHistoriesRepository : ISearchesHistoriesRepository
    {
        private readonly ISearchesHistoriesDao searchesHistoriesDao;
        public SearchesHistoriesRepository(ISearchesHistoriesDao searchesHistoriesDao)
        {
            this.searchesHistoriesDao = searchesHistoriesDao;
        }

        public async Task Insert(SearchHistoryModel entity) => await searchesHistoriesDao.Insert(entity); 

        public async Task<bool> Delete(string id) => (await searchesHistoriesDao.Delete(c => c.SearchId == id)) > 0;

        public async Task<PagedListModel<SearchHistoryModel>> GetBy(string searchId, int page, PageSizeEnum pageSize) => 
            await searchesHistoriesDao
                    .GetByFunc(c => c.SearchId == searchId, page, pageSize);
    }
}