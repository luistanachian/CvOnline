using Cv.Models;
using System.Net;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface IClientsBusiness
    {
        Task<HttpStatusCode> Save(ClientModel entity);
        Task<HttpStatusCode> Delete(string companyId, string clientId);
        Task<ClientModel> GetBy(string companyId, string clientId);
        Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, int pageSize, string name, int countryId, int stateId);
        Task<long> Count(string companyId, string name, int countryId, int stateId);

    }
}
