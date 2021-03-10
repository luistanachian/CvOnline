using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class ClientsRepository : IClientsRepository
    {
        private readonly IClientsDao clientsDao;
        private readonly FilterDefinitionBuilder<ClientModel> fd = Builders<ClientModel>.Filter;
        public ClientsRepository(IClientsDao clientsDao)
        {
            this.clientsDao = clientsDao;
        }

        public async Task Insert(ClientModel entity) => await clientsDao.Insert(entity);

        public async Task<bool> Replace(ClientModel entity) =>
            (await clientsDao.Replace(fd.Eq(c => c.ClientId, entity.ClientId), entity)) > 0;

        public async Task<bool> Delete(string clientId) =>
            (await clientsDao.Delete(fd.Eq(c => c.ClientId, clientId))) > 0;

        public async Task<ClientModel> GetBy(string clientId) =>
            await clientsDao.GetByFunc(fd.Eq(c => c.ClientId, clientId));

        public async Task<ClientModel> GetBy(string companyId, string code) =>
            await clientsDao.GetByFunc(fd.Where(c => c.CompanyId == companyId && c.Code == code));

        public async Task<PagedListModel<ClientModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, int countryId, int stateId) => 
            await clientsDao.GetByFunc(Filter(companyId, name, countryId, stateId), page, pageSize);

        public async Task<long> Count(string companyId, string name, int countryId, int stateId) => 
            await clientsDao.Count(Filter(companyId, name, countryId, stateId));

        private FilterDefinition<ClientModel> Filter(
            string companyId,
            string name,
            int countryId,
            int stateId)
        {
            name ??= string.Empty;
            name.Trim();

            var filterDefinitions = new List<FilterDefinition<ClientModel>>
            {
                fd.Eq(c => c.CompanyId, companyId)
            };

            if (countryId < 1)
                filterDefinitions.Add(fd.Eq(c => c.CountryId, countryId));

            if (stateId < 1)
                filterDefinitions.Add(fd.Eq(c => c.StateId, stateId));

            if (!string.IsNullOrWhiteSpace(name))
                filterDefinitions.Add(fd.Where(c => c.Name.Contains(name)));

            return fd.And(filterDefinitions);
        }
    }
}