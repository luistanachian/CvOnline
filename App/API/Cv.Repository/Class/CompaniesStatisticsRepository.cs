using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class CompaniesStatisticsRepository : ICompaniesStatisticsRepository
    {
        private readonly ICompaniesStatisticsDao companiesStatisticsDao;
        private readonly FilterDefinitionBuilder<CompanyStatisticsModel> fd = Builders<CompanyStatisticsModel>.Filter;
        public CompaniesStatisticsRepository(ICompaniesStatisticsDao companiesStatisticsDao)
        {
            this.companiesStatisticsDao = companiesStatisticsDao;
        }
        public async Task Insert(CompanyStatisticsModel entity) => await companiesStatisticsDao.Insert(entity);

        public async Task<bool> Replace(CompanyStatisticsModel entity) =>
            (await companiesStatisticsDao.Replace(fd.Eq(c => c.CompanyId, entity.CompanyId), entity)) > 0;

        public async Task<bool> Delete(string companyId) =>
            (await companiesStatisticsDao.Delete(fd.Eq(c => c.CompanyId, companyId))) > 0;

        public async Task<CompanyStatisticsModel> GetBy(string companyId) =>
            await companiesStatisticsDao.GetByFunc(fd.Eq(c => c.CompanyId, companyId));

    }
}