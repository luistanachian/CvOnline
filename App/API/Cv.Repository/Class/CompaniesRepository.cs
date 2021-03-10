using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class CompaniesRepository : ICompaniesRepository
    {
        private readonly ICompaniesDao companiesDao;
        private readonly FilterDefinitionBuilder<CompanyModel> fd = Builders<CompanyModel>.Filter;
        public CompaniesRepository(ICompaniesDao companiesDao)
        {
            this.companiesDao = companiesDao;
        }

        public async Task Insert(CompanyModel entity) => await companiesDao.Insert(entity);

        public async Task<bool> Replace(CompanyModel entity) => 
            (await companiesDao.Replace(fd.Eq(c => c.CompanyId, entity.CompanyId), entity)) > 0; 

        public async Task<bool> Delete(string id) => 
            (await companiesDao.Delete(fd.Eq(c => c.CompanyId, id))) > 0;

        public async Task<CompanyModel> GetBy(string id) => 
            await companiesDao.GetByFunc(fd.Eq(c => c.CompanyId, id));
    }
}