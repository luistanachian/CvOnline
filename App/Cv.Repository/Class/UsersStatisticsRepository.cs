using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;

namespace Cv.Repository.Class
{
    public sealed class UsersStatisticsRepository : IUsersStatisticsRepository
    {
        private readonly IUsersStatisticsDao usersStatisticsDao;
        public UsersStatisticsRepository(IUsersStatisticsDao usersStatisticsDao)
        {
            this.usersStatisticsDao = usersStatisticsDao;
        }
        public void Insert(UserStatisticsModel entity) => usersStatisticsDao.Insert(entity);

        public bool Replace(UserStatisticsModel entity) =>
            usersStatisticsDao.Replace(c => c.UserId == entity.UserId, entity) > 0;

        public bool Delete(string userId) =>
            usersStatisticsDao.Delete(c => c.UserId == userId) > 0;

        public UserStatisticsModel GetBy(string userId) =>
            usersStatisticsDao.GetOneByFunc(c => c.UserId == userId);
    }
}