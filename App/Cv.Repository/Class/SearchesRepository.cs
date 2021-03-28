using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class SearchesRepository : ISearchesRepository
    {
        private readonly ISearchesDao searchesDao;
        private readonly FilterDefinitionBuilder<SearchModel> fd = Builders<SearchModel>.Filter;
        public SearchesRepository(ISearchesDao searchesDao)
        {
            this.searchesDao = searchesDao;
        }

        public async Task Insert(SearchModel entity) => await searchesDao.Insert(entity);

        public async Task<bool> Replace(SearchModel entity) => 
            (await searchesDao.Replace(fd.Eq(c => c.SearchId, entity.SearchId), entity)) > 0; 

        public async Task<bool> Delete(string searchId) =>
            (await searchesDao.Delete(fd.Eq(c => c.SearchId, searchId))) > 0;

        public async Task<SearchModel> GetBy(string searchId) =>
                await searchesDao.GetByFunc(fd.Eq(c => c.SearchId, searchId));

        public async Task<PagedListModel<SearchModel>> GetBy(string clientId, int page, int pageSize) =>
                await searchesDao.GetByFunc(fd.Eq(c => c.ClientId, clientId), page, pageSize);

        public async Task<long> Count(string clientId) =>
                await searchesDao.Count(fd.Eq(c => c.ClientId, clientId));
    }
}