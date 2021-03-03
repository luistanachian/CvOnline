using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public sealed class SearchesRepository : ISearchesRepository
    {
        private readonly ISearchesDao searchesDao;
        public SearchesRepository(ISearchesDao searchesDao)
        {
            this.searchesDao = searchesDao;
        }

        public void Insert(SearchModel entity) => searchesDao.Insert(entity);

        public bool Replace(SearchModel entity) => 
            searchesDao.Replace(c => c.SearchId == entity.SearchId, entity) > 0; 

        public bool Delete(string searchId) =>
            searchesDao.Delete(c => c.SearchId == searchId) > 0;

        public SearchModel GetBy(string searchId) =>
                searchesDao.GetOneByFunc(c => c.SearchId == searchId);

        public List<SearchModel> GetBy(string clientId, int top) =>
                searchesDao.GetListByFunc(c => c.ClientId == clientId, top)
                    .OrderByDescending(c => c.DateCreated)
                    .ToList();

        public long GetCount(string clientId) =>
                searchesDao.GetCount(c => c.ClientId == clientId);
    }
}