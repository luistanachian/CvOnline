using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface IUsersStatisticsRepository
    {
        Task Insert(UserStatisticsModel entity);
        Task<bool> Replace(UserStatisticsModel entity);
        Task<bool> Delete(string userId);
        Task<UserStatisticsModel> GetBy(string userId);
    }
}
