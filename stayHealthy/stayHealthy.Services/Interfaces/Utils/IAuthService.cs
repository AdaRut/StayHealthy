using stayHealthy.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Interfaces.Utils
{
    public interface IAuthService
    {
        Task<AuthData> LoginAsync(UserLogin userLogin);
        Task<bool> ChangePasswordByUserAsync(UserPasswordChange passwordChange);
        Task<bool> ChangePasswordByAdminAsync(AdminPasswordChange passwordChange);
    }

}
