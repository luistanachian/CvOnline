using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class UsersStatisticsRepository : IUsersStatisticsRepository
    {
        private readonly IUsersStatisticsDao usersStatisticsDao;
        public UsersStatisticsRepository(IUsersStatisticsDao usersStatisticsDao)
        {
            this.usersStatisticsDao = usersStatisticsDao;
        }
        public async Task Insert(UserStatisticsModel entity) => await usersStatisticsDao.Insert(entity);

        public async Task<bool> Replace(UserStatisticsModel entity) =>
            (await usersStatisticsDao.Replace(c => c.UserId == entity.UserId, entity)) > 0;

        public async Task<bool> Delete(string userId) =>
            (await usersStatisticsDao.Delete(c => c.UserId == userId)) > 0;

        public async Task<UserStatisticsModel> GetBy(string userId) =>
            await usersStatisticsDao.GetByFunc(c => c.UserId == userId);
    }
}