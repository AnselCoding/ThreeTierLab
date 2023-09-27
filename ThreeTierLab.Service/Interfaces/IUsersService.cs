using ThreeTierLab.Common.Models;
using ThreeTierLab.DTOs;

namespace ThreeTierLab.Service
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAll(UserSearchInfo userSearchInfo);
        Task<User> Get(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<bool> IsItemExists(int id);
    }
}