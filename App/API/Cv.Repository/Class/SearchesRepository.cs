using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class SearchesRepository : ISearchesRepository
    {
        private readonly ISearchesDao searchesDao;
        public SearchesRepository(ISearchesDao searchesDao)
        {
            this.searchesDao = searchesDao;
        }

        public async Task Insert(SearchModel entity) => await searchesDao.Insert(entity);

        public async Task<bool> Replace(SearchModel entity) => 
            (await searchesDao.Replace(c => c.SearchId == entity.SearchId, entity)) > 0; 

        public async Task<bool> Delete(string searchId) =>
            (await searchesDao.Delete(c => c.SearchId == searchId)) > 0;

        public async Task<SearchModel> GetBy(string searchId) =>
                await searchesDao.GetByFunc(c => c.SearchId == searchId);

        public async Task<PagedListModel<SearchModel>> GetBy(string clientId, int page, PageSizeEnum pageSize) =>
                await searchesDao.GetByFunc(c => c.ClientId == clientId, page, pageSize);

        public async Task<long> Count(string clientId) =>
                await searchesDao.Count(c => c.ClientId == clientId);
    }
}