using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUsersDao usersDao;
        public UserRepository(IUsersDao usersDao)
        {
            this.usersDao = usersDao;
        }

        public void Insert(UserModel entity) => usersDao.Insert(entity);

        public bool Replace(UserModel entity) =>
            usersDao.Replace(c => c.UserId == entity.UserId, entity) > 0;

        public bool Delete(string userId) =>
            usersDao.Delete(c => c.UserId == userId) > 0;

        public UserModel GetBy(string userId) =>
            usersDao.GetOneByFunc(c => c.UserId == userId);

        public UserModel GetBy(string email, string password) =>
            usersDao.GetOneByFunc(c => c.Email == email && c.Password == password);

        public List<UserModel> GetBy(string companyId, int top, string name = null)
        {
                name = name?.Trim();

                return usersDao.GetListByFunc(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) ||
                        (c.Name.Contains(name) ||
                        c.LastName.Contains(name) ||
                        $"{c.Name} {c.LastName}".Contains(name) ||
                        $"{c.LastName} {c.Name}".Contains(name)))
                , top)
                    .OrderBy(c => c.Name)
                    .ThenBy(c => c.LastName)
                    .ToList();
        }

        public long GetCount(string companyId, string name = null)
        {
                name = name?.Trim();

                return usersDao.GetCount(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) ||
                        (c.Name.Contains(name) ||
                        c.LastName.Contains(name) ||
                        $"{c.Name} {c.LastName}".Contains(name) ||
                        $"{c.LastName} {c.Name}".Contains(name))));
        }
    }
}