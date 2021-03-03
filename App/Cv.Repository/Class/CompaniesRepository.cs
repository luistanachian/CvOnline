using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;

namespace Cv.Repository.Class
{
    public sealed class CompaniesRepository : ICompaniesRepository
    {
        private readonly ICompaniesDao companiesDao;
        public CompaniesRepository(ICompaniesDao companiesDao)
        {
            this.companiesDao = companiesDao;
        }

        public void Insert(CompanyModel entity) => 
            companiesDao.Insert(entity);

        public bool Replace(CompanyModel entity) => 
            companiesDao.Replace(c => c.CompanyId == entity.CompanyId, entity) > 0; 

        public bool Delete(string id) => 
            companiesDao.Delete(c => c.CompanyId == id) > 0;

        public CompanyModel GetBy(string id) => 
            companiesDao.GetOneByFunc(c => c.CompanyId == id);
    }
}