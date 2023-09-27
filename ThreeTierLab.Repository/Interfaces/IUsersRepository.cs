using ThreeTierLab.Common.Models;
using ThreeTierLab.DTOs;

namespace ThreeTierLab.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll(UserSearchInfo userSearchInfo);
        public Task<User> Get(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
