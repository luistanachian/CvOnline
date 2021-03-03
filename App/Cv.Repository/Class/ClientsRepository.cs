using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public sealed class ClientsRepository : IClientsRepository
    {
        private readonly IClientsDao clientsDao;
        public ClientsRepository(IClientsDao clientsDao)
        {
            this.clientsDao = clientsDao;
        }

        public void Insert(ClientModel entity) => clientsDao.Insert(entity);

        public bool Replace(ClientModel entity) => 
            clientsDao.Replace(c => c.ClientId == entity.ClientId, entity) > 0;

        public bool Delete(string clientId) =>
            clientsDao.Delete(c => c.ClientId == clientId) > 0;

        public ClientModel GetBy(string clientId) => 
            clientsDao.GetOneByFunc(c => c.ClientId == clientId);

        public ClientModel GetBy(string companyId, string code) => 
            clientsDao.GetOneByFunc(c => c.CompanyId == companyId && c.Code == code);

        public List<ClientModel> GetBy(
            string companyId,
            int top,
            string name = null,
            int? countryId = null,
            int? stateId = null)
        {
                name = name?.Trim();

                return clientsDao.GetListByFunc(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name)) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId)
                , top)
                    .OrderBy(c => c.Name)
                    .ToList();
        }

        public long GetCount(
            string companyId,
            string name = null,
            int? countryId = null,
            int? stateId = null)
        {
                name = name?.Trim();

                return clientsDao.GetCount(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name)) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId));
        }
    }
}