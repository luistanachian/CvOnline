using Cv.Models;

namespace Cv.Repository.Interface
{
    public interface IUsersStatisticsRepository
    {
        void Insert(UserStatisticsModel entity);
        public bool Replace(UserStatisticsModel entity);
        public bool Delete(string userId);
        public UserStatisticsModel GetBy(string userId);
    }
}
