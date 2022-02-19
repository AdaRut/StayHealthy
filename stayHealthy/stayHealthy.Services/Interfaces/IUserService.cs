using stayHealthy.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(UserAdd userAdd);
        Task<User> UpdateUserAsync(UserModify userModify);
        Task<User> GetUserAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> DeleteAsync(int userId, int deletedById);
    }
}
