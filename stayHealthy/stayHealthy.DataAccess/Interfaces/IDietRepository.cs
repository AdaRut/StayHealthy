using stayHealthy.DataAccess.Entities;
using stayHealthy.DataAccess.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Interfaces
{
    public interface IDietRepository : IRepositoryBase<DietEntity>
    {
        new Task<IEnumerable<DietEntity>> GetAllAsync();
        Task<IEnumerable<DietEntity>> GetAllUserDietAsync(int userId);
        Task<DietEntity> GetDietByIdAsync(int id);
    }
}
