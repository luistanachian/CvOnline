using Cv.Models;
using Cv.Models.Enums;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface ISearchesRepository
    {
        public void Insert(SearchModel entity);
        public bool Replace(SearchModel entity);
        public bool Delete(string searchId);
        public SearchModel GetBy(string searchId);
        public List<SearchModel> GetBy(string clientId, PageSizeEnum lines);
        public long GetCount(string clientId);
    }
}
