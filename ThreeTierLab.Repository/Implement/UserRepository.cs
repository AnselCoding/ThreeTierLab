using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTierLab.Common.Models;
using ThreeTierLab.DTOs;
using ThreeTierLab.Repository.Models;

namespace ThreeTierLab.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly LabDBContext _dbContext;
        public UserRepository(LabDBContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<User>> GetAll(UserSearchInfo userSearchInfo)
        {
            IEnumerable<User> users = await _dbContext.Users.ToListAsync();
            // 使用者 Id 搜尋上限
            if (userSearchInfo.UpperLimitId != null)
                users = users.Where(x => x.Id < userSearchInfo.UpperLimitId).ToList();
            // 使用者 Id 搜尋下限
            if (userSearchInfo.LowerLimitId != null)
                users = users.Where(x => x.Id > userSearchInfo.LowerLimitId).ToList();
            // 使用者帳號關鍵字搜尋
            if (userSearchInfo.Name != null)
                users = users.Where(x => x.Name.Contains(userSearchInfo.Name)).ToList();
            // 使用者行動電話關鍵字搜尋
            if (userSearchInfo.MobilePhone != null)
                users = users.Where(x => x.MobilePhone != null && x.MobilePhone.Contains(userSearchInfo.MobilePhone)).ToList();
            // 使用者身分選項搜尋
            if (userSearchInfo.Role != null)
                users = users.Where(x => x.Role == userSearchInfo.Role).ToList();
            // 使用者信箱關鍵字搜尋
            if (userSearchInfo.Email != null)
                users = users.Where(x => x.Email != null && x.Email.Contains(userSearchInfo.Email)).ToList();

            return users;
        }

        public async Task<User> Get(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            // 檢查是否已經追蹤這個實體
            var existingEntry = _dbContext.ChangeTracker.Entries<User>()
                .FirstOrDefault(e => e.Entity.Id == user.Id);

            if (existingEntry == null)
            {
                // 如果不存在，則將實體附加到DbContext
                _dbContext.Entry(user).State = EntityState.Modified;
            }
            else
            {
                // 如果已經存在，則更新現有實體的屬性值
                existingEntry.CurrentValues.SetValues(user);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

    }
}
