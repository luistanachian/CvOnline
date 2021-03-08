using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class ClientsRepository : IClientsRepository
    {
        private readonly IClientsDao clientsDao;
        public ClientsRepository(IClientsDao clientsDao)
        {
            this.clientsDao = clientsDao;
        }

        public async Task Insert(ClientModel entity) => await clientsDao.Insert(entity);

        public async Task<bool> Replace(ClientModel entity) =>
            (await clientsDao.Replace(c => c.ClientId == entity.ClientId, entity)) > 0;

        public async Task<bool> Delete(string clientId) =>
            (await clientsDao.Delete(c => c.ClientId == clientId)) > 0;

        public async Task<ClientModel> GetBy(string clientId) =>
            await clientsDao.GetByFunc(c => c.ClientId == clientId);

        public async Task<ClientModel> GetBy(string companyId, string code) =>
            await clientsDao.GetByFunc(c => c.CompanyId == companyId && c.Code == code);

        public async Task<PagedListModel<ClientModel>> GetBy(
            string companyId,
            int page,
            PageSizeEnum pageSize,
            string name,
            int countryId,
            int stateId)
        {
            name = name?.Trim();

            return await clientsDao.GetByFunc(c =>
                c.CompanyId == companyId &&
                (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name)) &&
                (countryId < 1 || c.CountryId == countryId) &&
                (stateId < 1 || c.StateId == stateId)
                , page
                , pageSize);
        }

        public async Task<long> Count(
            string companyId,
            string name,
            int countryId,
            int stateId)
        {
            name = name?.Trim();

            return await clientsDao.Count(c =>
                c.CompanyId == companyId &&
                (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name)) &&
                (countryId < 1 || c.CountryId == countryId) &&
                (stateId < 1 || c.StateId == stateId));
        }
    }
}