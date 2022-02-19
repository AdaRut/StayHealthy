using AutoMapper;
using stayHealthy.DataAccess.Entities;
using stayHealthy.DataAccess.Interfaces;
using stayHealthy.Services.Interfaces;
using stayHealthy.Services.Interfaces.Utils;
using stayHealthy.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IHashService hashService;
        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IHashService hashService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.hashService = hashService;
        }

        public async Task<User> AddUserAsync(UserAdd userAdd)
        {
            var userEntity = new UserEntity
            {
                Username = userAdd.Username,
                Password = hashService.HashPassword(userAdd.Password),
                Email = userAdd.Email,
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
                Role = userAdd.Role.ToString(),
                CreationDate = DateTime.Now,
                IsDeleted = false
            };
            userRepository.Add(userEntity);
            await userRepository.SaveChangesAsync();
            userEntity = await userRepository.GetByIdAsync(userEntity.Id);

            var user = mapper.Map<User>(userEntity);
            return user;
        }

        public async Task<User> DeleteAsync(int userId, int deletedById)
        {
            var userEntity = await userRepository.GetByIdAsync(userId);

            userEntity.IsDeleted = true;
            userEntity.ModificationDate = DateTime.Now;

            userRepository.Update(userEntity);
            await userRepository.SaveChangesAsync();
            return await GetUserAsync(userEntity.Id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var userEntities = await userRepository.GetAllAsync();
            return mapper.Map<IEnumerable<User>>(userEntities);
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var userEntity = await userRepository.GetByIdAsync(userId);
            return mapper.Map<User>(userEntity);
        }

        public async Task<User> UpdateUserAsync(UserModify userModify)
        {
            var userEntity = await userRepository.GetByIdAsync(userModify.Id);

            userEntity.FirstName = userModify.FirstName;
            userEntity.LastName = userModify.LastName;
            userEntity.Email = userModify.Email;
            userEntity.ModificationDate = DateTime.Now;

            userRepository.Update(userEntity);
            await userRepository.SaveChangesAsync();
            userEntity = await userRepository.GetByIdAsync(userEntity.Id);
            return mapper.Map<User>(userEntity);
        }
    }
}
