using Cv.Models;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface IClientsRepository
    {
        void Insert(ClientModel entity);
        bool Replace(ClientModel entity);
        bool Delete(string clientId);
        ClientModel GetBy(string clientId);
        ClientModel GetBy(string companyId, string code);
        List<ClientModel> GetBy(string companyId, int top, string name = null, int? countryId = null, int? stateId = null);
        long GetCount(string companyId, string name = null, int? countryId = null, int? stateId = null);
    }
}
