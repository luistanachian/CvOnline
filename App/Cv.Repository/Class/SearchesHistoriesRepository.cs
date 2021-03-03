using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public class SearchesHistoriesRepository : ISearchesHistoriesRepository
    {
        private readonly ISearchesHistoriesDao searchesHistoriesDao;
        public SearchesHistoriesRepository(ISearchesHistoriesDao searchesHistoriesDao)
        {
            this.searchesHistoriesDao = searchesHistoriesDao;
        }

        public void Insert(SearchHistoryModel entity) => searchesHistoriesDao.Insert(entity); 

        public bool Delete(string id) => searchesHistoriesDao.Delete(c => c.SearchId == id) > 0;

        public List<SearchHistoryModel> GetBy(string searchId, int top) => 
            searchesHistoriesDao
                    .GetListByFunc(c => c.SearchId == searchId, top)
                    .Select(c => new SearchHistoryModel 
                    { 
                        SearchId = c.SearchId,
                        History = c.History.OrderByDescending(h => h.Date).ToList()
                    })
                    .ToList();
    }
}