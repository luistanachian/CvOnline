using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUsersDao usersDao;
        private readonly FilterDefinitionBuilder<UserModel> fd = Builders<UserModel>.Filter;
        public UserRepository(IUsersDao usersDao)
        {
            this.usersDao = usersDao;
        }

        public async Task Insert(UserModel entity) => await usersDao.Insert(entity);

        public async Task<bool> Replace(UserModel entity) =>
            (await usersDao.Replace(fd.Eq(c => c.UserId, entity.UserId), entity)) > 0;

        public async Task<bool> Delete(string userId) =>
            (await usersDao.Delete(fd.Eq(c => c.UserId, userId))) > 0;

        public async Task<UserModel> GetBy(string userId) =>
            await usersDao.GetByFunc(fd.Eq(c => c.UserId, userId));

        public async Task<UserModel> GetBy(string email, string password) =>
            await usersDao.GetByFunc(fd.Where(c => c.Email == email && c.Password == password));

        public async Task<PagedListModel<UserModel>> GetBy(string companyId, int page, int pageSize, string name) => 
            await usersDao.GetByFunc(Filter(companyId, name), page, pageSize);

        public async Task<long> Count(string companyId, string name) => 
            await usersDao.Count(Filter(companyId, name));

        private FilterDefinition<UserModel> Filter(string companyId, string name)
        {
            name ??= string.Empty;
            name = name.Trim();

            var filterDefinitions = new List<FilterDefinition<UserModel>>
            {
                fd.Eq(c => c.CompanyId, companyId)
            };

            if (!string.IsNullOrWhiteSpace(name))
                filterDefinitions.Add(fd.Where(c => c.Name.Contains(name) || c.LastName.Contains(name)));

            return fd.And(filterDefinitions);
        }
    }
}