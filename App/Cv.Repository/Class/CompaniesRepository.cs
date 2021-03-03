using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;

namespace Cv.Repository.Class
{
    public sealed class CompaniesRepository : ICompaniesRepository
    {
        private readonly ICompaniesDao companiesDao;
        public CompaniesRepository(ICompaniesDao companiesDao)
        {
            this.companiesDao = companiesDao;
        }

        public bool Insert(CompanyModel entity)
        {
            try
            {
                companiesDao.Insert(entity);
                return true;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }

        public bool Replace(CompanyModel entity)
        {
            try
            {
                return companiesDao.Replace(c => c.CompanyId == entity.CompanyId, entity) > 0;
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
                return companiesDao.Delete(c => c.CompanyId == id) > 0;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }

        public CompanyModel GetBy(string id)
        {
            try
            {
                return companiesDao.GetOneByFunc(c => c.CompanyId == id);
            }
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }
    }
}