using Cv.Models;
using Cv.Models.Helpers;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface IClientsRepository
    {
        Task Insert(ClientModel entity);
        Task<bool> Replace(ClientModel entity);
        Task<bool> Delete(string companyId, string clientId);
        Task<ClientModel> GetBy(string companyId, string clientId);
        Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, int pageSize, string name, int countryId, int stateId);
        Task<long> Count(string companyId, string name, int countryId, int stateId);
    }
}
