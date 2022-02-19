using stayHealthy.DataAccess.Entities;
using stayHealthy.DataAccess.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Interfaces
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        Task<UserEntity> GetByUsernameAsync(string username);
        Task<bool> IsUsernameUniqueAsync(string username);
        Task<bool> IsEmailUniqueAsync(string email);
        new Task<IEnumerable<UserEntity>> GetAllAsync();
    }
}
