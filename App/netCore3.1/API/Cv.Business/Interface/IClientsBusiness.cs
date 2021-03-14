using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface IClientsBusiness
    {
        Task<ResultBus<bool>> Insert(ClientModel entity);
        Task<ResultBus<bool>> Replace(ClientModel entity);
        Task<bool> Delete(string id);
        Task<ClientModel> GetBy(string clientId);
        Task<ClientModel> GetBy(string companyId, string code);
        Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, int countryId, int stateId);
        Task<long> Count(string companyId, string name, int countryId, int stateId);

    }
}
