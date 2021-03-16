using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
using System.Threading.Tasks;
using Cv.Models.Helpers;

namespace Cv.Business.Class
{
    public sealed class ClientsBusiness : IClientsBusiness
    {
        private readonly IClientsRepository clientsRepository;
        public ClientsBusiness(IClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }
        public async Task<ResultBus> Insert(ClientModel entity)
        {
            var result = new ResultBus();
            try
            {
                entity.ClientId = Guid.NewGuid().ToString();
                entity.StarDate = DateTime.Now;
                    if (await clientsRepository.CodeExists(entity.CompanyId, entity.ClientId, entity.Code))
                        result.AddError("El codigo ya existe");
                    else
                        await clientsRepository.Insert(entity);
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<ResultBus> Replace(ClientModel entity)
        {
            var result = new ResultBus();
            try
            {
                    if (await clientsRepository.CodeExists(entity.CompanyId, entity.ClientId, entity.Code))
                        result.AddError("El codigo ya existe");
                    else if (!await clientsRepository.Replace(entity))
                        result.AddError("No se guardo");
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<ResultBus> Delete(string id)
        {
            var result = new ResultBus();
            try
            {
                if (!await clientsRepository.Delete(id))
                    result.AddError("No se elimino");
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
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