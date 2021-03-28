using Cv.Models;
using System.Threading.Tasks;

namespace Cv.Repository.Interface
{
    public interface IUserRepository
    {
        Task Insert(UserModel entity);
        Task<bool> Replace(UserModel entity);
        Task<bool> Delete(string userId);
        Task<UserModel> GetBy(string userId);
        Task<UserModel> GetBy(string email, string password);
        Task<PagedListModel<UserModel>> GetBy(string companyId, int page, int pageSize, string name);
        Task<long> Count(string companyId, string name);
    }
}