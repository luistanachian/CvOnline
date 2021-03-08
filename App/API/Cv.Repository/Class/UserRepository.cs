using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUsersDao usersDao;
        public UserRepository(IUsersDao usersDao)
        {
            this.usersDao = usersDao;
        }

        public async Task Insert(UserModel entity) => await usersDao.Insert(entity);

        public async Task<bool> Replace(UserModel entity) =>
            (await usersDao.Replace(c => c.UserId == entity.UserId, entity)) > 0;

        public async Task<bool> Delete(string userId) =>
            (await usersDao.Delete(c => c.UserId == userId)) > 0;

        public async Task<UserModel> GetBy(string userId) =>
            await usersDao.GetByFunc(c => c.UserId == userId);

        public async Task<UserModel> GetBy(string email, string password) =>
            await usersDao.GetByFunc(c => c.Email == email && c.Password == password);

        public async Task<PagedListModel<UserModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name)
        {
                name = name.Trim();

                return await usersDao.GetByFunc(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) ||
                        (c.Name.Contains(name) ||
                        c.LastName.Contains(name) ||
                        $"{c.Name} {c.LastName}".Contains(name) ||
                        $"{c.LastName} {c.Name}".Contains(name)))
                        , page
                        , pageSize);
        }

        public async Task<long> Count(string companyId, string name)
        {
                name = name.Trim();

                return await usersDao.Count(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) ||
                        (c.Name.Contains(name) ||
                        c.LastName.Contains(name) ||
                        $"{c.Name} {c.LastName}".Contains(name) ||
                        $"{c.LastName} {c.Name}".Contains(name))));
        }
    }
}