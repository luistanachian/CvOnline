﻿using Cv.Models;
using Cv.Models.Helpers;
using System.Net;
using System.Threading.Tasks;

namespace Cv.Business.Interface
{
    public interface IClientsBusiness
    {
        Task<HttpStatusCode> Save(ClientModel entity);
        Task<HttpStatusCode> Delete(string companyId, string clientId);
        Task<ClientModel> GetBy(string clientId);
        Task<ClientModel> GetBy(string companyId, string code);
        Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, int pageSize, string name, int countryId, int stateId);
        Task<long> Count(string companyId, string name, int countryId, int stateId);

    }
}
