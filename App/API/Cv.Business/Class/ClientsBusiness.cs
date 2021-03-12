using Cv.Business.Interface;
using Cv.Models;
using Cv.Business.Validations;
using Cv.Repository.Interface;
using System;
using Cv.Models.Enums;
using System.Threading.Tasks;
using Cv.Models.Helpers;
using System.Collections.Generic;

namespace Cv.Business.Class
{
    public sealed class ClientsBusiness : IClientsBusiness
    {
        private readonly IClientsRepository clientsRepository;
        public ClientsBusiness(IClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }
        public async Task<ResultBus<bool>> Insert(ClientModel entity)
        {
            var result = new ResultBus<bool>();
            try
            {
                entity.ClientId = Guid.NewGuid().ToString();
                entity.StarDate = DateTime.Now;
                var errores = new List<string>();

                if (Validator.ValidatePredicates(entity, ClientValidate.Predicates, out errores))
                {
                    await clientsRepository.Insert(entity);
                    result.Ok = true;
                }
                else
                    result.AddError(errores);
            }
            catch (Exception)
            {
                result.AddError("Error");
            }
            result.Result = result.Ok;
            return result;
        }
        public async Task<ResultBus<bool>> Replace(ClientModel entity)
        {
            var result = new ResultBus<bool>();
            try
            {
                var errores = new List<string>();
                if (Validator.ValidatePredicates(entity, ClientValidate.Predicates, out errores))
                {
                    await clientsRepository.Replace(entity);
                    result.Ok = true;
                }
                else
                    result.AddError(errores);
            }
            catch (Exception)
            {
                result.AddError("Error");
            }
            result.Result = result.Ok;
            return result;
        }
        public async Task<bool> Delete(string id)
        {
            if (Validator.Guid(id))
                return await clientsRepository.Delete(id);

            return false;
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