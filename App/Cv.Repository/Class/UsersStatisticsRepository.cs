using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class UsersStatisticsRepository : IUsersStatisticsRepository
    {
        private readonly IUsersStatisticsDao usersStatisticsDao;
        private readonly FilterDefinitionBuilder<UserStatisticsModel> fd = Builders<UserStatisticsModel>.Filter;
        public UsersStatisticsRepository(IUsersStatisticsDao usersStatisticsDao)
        {
            this.usersStatisticsDao = usersStatisticsDao;
        }
        public async Task Insert(UserStatisticsModel entity) => await usersStatisticsDao.Insert(entity);

        public async Task<bool> Replace(UserStatisticsModel entity) =>
            (await usersStatisticsDao.Replace(fd.Eq(c => c.UserId, entity.UserId), entity)) > 0;

        public async Task<bool> Delete(string userId) =>
            (await usersStatisticsDao.Delete(fd.Eq(c => c.UserId, userId))) > 0;

        public async Task<UserStatisticsModel> GetBy(string userId) =>
            await usersStatisticsDao.GetByFunc(fd.Eq(c => c.UserId, userId));
    }
}