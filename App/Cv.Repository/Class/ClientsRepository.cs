using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System;
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

        public bool Insert(ClientModel client)
        {
            try
            {
                clientsDao.Insert(client);
                return true;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }

        public bool Replace(ClientModel client)
        {
            try
            {
                return clientsDao.Replace(c => c.ClientId == client.ClientId, client) > 0;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                return clientsDao.Delete(c => c.ClientId == id) > 0;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }

        public ClientModel GetBy(string clientId)
        {
            try
            {
                return clientsDao.GetOneByFunc(c => c.ClientId == clientId);
            }
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }

        public ClientModel GetBy(string companyId, string code)
        {
            try
            {
                return clientsDao.GetOneByFunc(c =>
                c.CompanyId == companyId &&
                c.Code == code);
            }
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }

        public List<ClientModel> GetBy(
            string companyId,
            int top,
            string name = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
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
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }

        public long GetCount(
            string companyId,
            string name = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                name = name?.Trim();

                return clientsDao.GetCount(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name)) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId));
            }
            catch (Exception)
            {
                //TODO loguear
                return 0;
            }
        }
    }
}