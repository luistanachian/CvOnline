using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System;
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

        public bool Insert(SearchHistoryModel entity)
        {
            try
            {
                searchesHistoriesDao.Insert(entity);
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
                return searchesHistoriesDao.Delete(c => c.SearchId == id) > 0;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }
        public List<SearchHistoryModel> GetBy(string searchId, int top)
        {
            try
            {
                return searchesHistoriesDao
                    .GetListByFunc(c => c.SearchId == searchId, top)
                    .Select(c => new SearchHistoryModel 
                    { 
                        SearchId = c.SearchId,
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