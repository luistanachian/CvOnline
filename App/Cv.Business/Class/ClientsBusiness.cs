using Cv.Business.Interface;
using Cv.Models;
using Cv.Business.Validations;
using Cv.Repository.Interface;
using System;
using Cv.Models.Enums;
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
                if (Validator.ValidatePredicates(entity, ClientValidate.Predicates, ref result))
                {
                    if (await clientsRepository.CodeExists(entity.CompanyId, entity.ClientId, entity.Code))
                        result.AddError("El codigo ya existe");
                    else
                        await clientsRepository.Insert(entity);
                }
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<ResultBus> Replace(ClientModel entity)
        {
            var result = new ResultBus();
            try
            {
                if (Validator.ValidatePredicates(entity, ClientValidate.Predicates, ref result))
                {
                    if (await clientsRepository.CodeExists(entity.CompanyId, entity.ClientId, entity.Code))
                        result.AddError("El codigo ya existe");
                    else if (!await clientsRepository.Replace(entity))
                        result.AddError("No se guardo");
                }
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<ResultBus> Delete(string id)
        {
            var result = new ResultBus();
            try
            {
                if (!Validator.Guid(id) && !await clientsRepository.Delete(id))
                    result.AddError("No se elimino");
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<ClientModel> GetBy(string clientId)
        {
            if (Validator.Guid(clientId))
                return await clientsRepository.GetBy(clientId);

            return null;
        }
        public async Task<ClientModel> GetBy(string companyId, string code)
        {
            if (Validator.Guid(companyId))
                return await clientsRepository.GetBy(companyId, code);

            return null;
        }
        public async Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, int countryId, int stateId)
        {
            if (Validator.Guid(companyId))
                return await clientsRepository.GetBy(companyId, page, pageSize, name, countryId, stateId);

            return null;
        }
        public async Task<long> Count(string companyId, string name, int countryId, int stateId)
        {
            if (Validator.Guid(companyId))
                return await clientsRepository.Count(companyId, name, countryId, stateId);

            return 0;
        }
    }
}