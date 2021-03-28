using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
using System.Threading.Tasks;
using System.Net;

namespace Cv.Business.Class
{
    public sealed class ClientsBusiness : IClientsBusiness
    {
        private readonly IClientsRepository clientsRepository;
        public ClientsBusiness(IClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }
        public async Task<HttpStatusCode> Save(ClientModel entity)
        {
            entity.ClientId = string.IsNullOrWhiteSpace(entity.ClientId) ? null : entity.ClientId;
            if (entity.ClientId == null)
            {
                entity.ClientId = Guid.NewGuid().ToString();
                await clientsRepository.Insert(entity);
                return HttpStatusCode.OK;
            }
            else if (!await clientsRepository.Replace(entity))
                return HttpStatusCode.OK;

            return HttpStatusCode.NotModified;
        }
        public async Task<HttpStatusCode> Delete(string companyId, string clientId)
        {
            if (!await clientsRepository.Delete(companyId, clientId))
                return HttpStatusCode.OK;

            return HttpStatusCode.NotModified;
        }
        public async Task<ClientModel> GetBy(string companyId, string code) => 
            await clientsRepository.GetBy(companyId, code);

        public async Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, int pageSize, string name, int countryId, int stateId) => 
            await clientsRepository.GetBy(companyId, page, pageSize, name, countryId, stateId);

        public async Task<long> Count(string companyId, string name, int countryId, int stateId) => 
            await clientsRepository.Count(companyId, name, countryId, stateId);
    }
}