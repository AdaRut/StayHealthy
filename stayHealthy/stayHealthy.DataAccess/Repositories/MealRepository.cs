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
    public class MealRepository : RepositoryBase<MealEntity>, IMealRepository
    {
        public MealRepository(StayHealthyContext stayHealthyContext) : base(stayHealthyContext)
        {

        }

        public void AddRange(IEnumerable<MealEntity> entities)
        {
            StayHealthyContext.Meals.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<MealEntity>> GetAllDietMealsAsync(int dietId)
        {
            return await StayHealthyContext.Meals
                .Where(x => !x.IsDeleted && x.DietId == dietId)
                .ToListAsync();
        }

        public void UpdateRange(IEnumerable<MealEntity> entities)
        {
            StayHealthyContext.Meals.UpdateRange(entities);
        }
    }
}
