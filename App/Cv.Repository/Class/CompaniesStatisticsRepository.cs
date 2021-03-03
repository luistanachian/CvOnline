using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;

namespace Cv.Repository.Class
{
    public sealed class CompaniesStatisticsRepository : ICompaniesStatisticsRepository
    {
        private readonly ICompaniesStatisticsDao companiesStatisticsDao;
        public CompaniesStatisticsRepository(ICompaniesStatisticsDao companiesStatisticsDao)
        {
            this.companiesStatisticsDao = companiesStatisticsDao;
        }
        public void Insert(CompanyStatisticsModel entity) => companiesStatisticsDao.Insert(entity);

        public bool Replace(CompanyStatisticsModel entity) =>
            companiesStatisticsDao.Replace(c => c.CompanyId == entity.CompanyId, entity) > 0;

        public bool Delete(string id) =>
            companiesStatisticsDao.Delete(c => c.CompanyId == id) > 0;

        public CompanyStatisticsModel GetBy(string companyId) =>
            companiesStatisticsDao.GetOneByFunc(c => c.CompanyId == companyId);

    }
}