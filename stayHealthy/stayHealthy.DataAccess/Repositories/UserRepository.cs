using Microsoft.EntityFrameworkCore;
using stayHealthy.DataAccess.Entities;
using stayHealthy.DataAccess.Interfaces;
using stayHealthy.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(StayHealthyContext stayHealthyContext) : base(stayHealthyContext)
        {

        }

        public async Task<UserEntity> GetByUsernameAsync(string username)
        {
            return await StayHealthyContext.Set<UserEntity>().FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !(await StayHealthyContext.Set<UserEntity>().AnyAsync(x => x.Email == email && !x.IsDeleted));
        }

        public async Task<bool> IsUsernameUniqueAsync(string username)
        {
            return !(await StayHealthyContext.Set<UserEntity>().AnyAsync(x => x.Username == username && !x.IsDeleted));
        }

        public async new Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await StayHealthyContext.Users.Where(x => !x.IsDeleted).ToListAsync();
        }
    }
}
