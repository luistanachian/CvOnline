using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface IClientsRepository
    {
        bool Insert(ClientModel client);
        bool Replace(ClientModel client);
        bool Delete(string id);
        ClientModel GetBy(string clientId);
        ClientModel GetBy(string companyId, string code);
        List<ClientModel> GetBy(string companyId, int top, string name = null, int? countryId = null, int? stateId = null);
        long GetCount(string companyId, string name = null, int? countryId = null, int? stateId = null);
    }
}
