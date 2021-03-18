using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
using System.Threading.Tasks;
using Cv.Models.Helpers;
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
            try
            {
                entity.ClientId = string.IsNullOrWhiteSpace(entity.ClientId) ? null : entity.ClientId;
                if (!string.IsNullOrWhiteSpace(entity.Code))
                {
                    if (await clientsRepository.CodeExists(entity.CompanyId, entity.ClientId, entity.Code))
                        return HttpStatusCode.BadRequest;
                }

                if (entity.ClientId == null)
                {
                    entity.ClientId = Guid.NewGuid().ToString();
                    entity.StarDate = DateTime.Now;
                    await clientsRepository.Insert(entity);
                    return HttpStatusCode.OK;
                }
                else if (!await clientsRepository.Replace(entity))
                    return HttpStatusCode.OK;
                else
                    return HttpStatusCode.NotModified;
            }
            catch (Exception) { return HttpStatusCode.InternalServerError; }
        }
        public async Task<HttpStatusCode> Delete(string companyId, string clientId)
        {
            try
            {
                if (!await clientsRepository.Delete(companyId, clientId))
                    return HttpStatusCode.OK;

                return HttpStatusCode.NotModified;
            }
            catch (Exception) { return HttpStatusCode.InternalServerError; }
        }
        public async Task<ClientModel> GetBy(string clientId)
        {
            return await clientsRepository.GetBy(clientId);
        }
        public async Task<ClientModel> GetBy(string companyId, string code)
        {
            return await clientsRepository.GetBy(companyId, code);
        }
        public async Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, int pageSize, string name, int countryId, int stateId)
        {
            return await clientsRepository.GetBy(companyId, page, pageSize, name, countryId, stateId);
        }
        public async Task<long> Count(string companyId, string name, int countryId, int stateId)
        {
            return await clientsRepository.Count(companyId, name, countryId, stateId);
        }
    }
}