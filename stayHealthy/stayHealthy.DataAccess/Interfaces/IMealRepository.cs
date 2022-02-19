using stayHealthy.DataAccess.Entities;
using stayHealthy.DataAccess.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Interfaces
{
    public interface IMealRepository : IRepositoryBase<MealEntity>
    {
        Task<IEnumerable<MealEntity>> GetAllDietMealsAsync(int dietId);
        void AddRange(IEnumerable<MealEntity> entities);
        void UpdateRange(IEnumerable<MealEntity> entities);
    }
}
