using ThreeTierLab.Common.Models;
using ThreeTierLab.DTOs;
using ThreeTierLab.Repository;

namespace ThreeTierLab.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<User>> GetAll(UserSearchInfo userSearchInfo)
        {
            return await _usersRepository.GetAll(userSearchInfo);
        }
        public async Task<User> Get(int id)
        {
            return await _usersRepository.Get(id);
        }
        public async Task Create(User user)
        {
            await _usersRepository.Create(user);
        }
        public async Task Update(User user)
        {
            await _usersRepository.Update(user);
        }

        public async Task Delete(User user)
        {
            await _usersRepository.Delete(user);
        }

        public async Task<bool> IsItemExists(int id)
        {
            return await _usersRepository.Get(id) != null;
        }

    }
}
