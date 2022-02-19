using AutoMapper;
using stayHealthy.DataAccess.Interfaces;
using stayHealthy.Services.Interfaces.Utils;
using stayHealthy.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Services.Utils
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IHashService hashService;
        private readonly ITokenGeneratorService tokenGeneratorService;
        private readonly IMapper mapper;
        private readonly IAuthProvider authProvider;

        public AuthService(
            IUserRepository userRepository,
            IHashService hashService,
            ITokenGeneratorService tokenGeneratorService,
            IMapper mapper,
            IAuthProvider authProvider)
        {
            this.userRepository = userRepository;
            this.hashService = hashService;
            this.tokenGeneratorService = tokenGeneratorService;
            this.mapper = mapper;
            this.authProvider = authProvider;
        }

        public async Task<AuthData> LoginAsync(UserLogin userLogin)
        {
            var userEnity = await userRepository.GetByUsernameAsync(userLogin.Username);
            if (userEnity != null && !userEnity.IsDeleted)
            {
                bool passwordIsCorrect = hashService.Validate(userLogin.Password, userEnity.Password);
                if (passwordIsCorrect)
                {
                    var token = tokenGeneratorService.GenerateToken(userEnity.Id, userEnity.Role);
                    var user = mapper.Map<User>(userEnity);
                    return new AuthData
                    {
                        Token = token,
                        User = user
                    };
                }
            }
            return null;
        }

        public async Task<bool> ChangePasswordByUserAsync(UserPasswordChange passwordChange)
        {
            var userId = authProvider.GetUserId();
            var userEnity = await userRepository.GetByIdAsync(userId);
            if (userEnity != null)
            {
                bool passwordIsCorrect = hashService.Validate(passwordChange.CurrentPassword, userEnity.Password);
                if (passwordIsCorrect)
                {
                    userEnity.Password = hashService.HashPassword(passwordChange.NewPassword);
                    userEnity.ModificationDate = DateTime.Now;

                    userRepository.Update(userEnity);
                    await userRepository.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ChangePasswordByAdminAsync(AdminPasswordChange passwordChange)
        {
            var userEnity = await userRepository.GetByIdAsync(passwordChange.UserId);
            if (userEnity != null)
            {
                userEnity.Password = hashService.HashPassword(passwordChange.NewPassword);
                userEnity.ModificationDate = DateTime.Now;

                userRepository.Update(userEnity);
                await userRepository.SaveChangesAsync();
                return true;

            }
            return false;
        }
    }
}
