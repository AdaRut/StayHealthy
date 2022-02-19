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
    public class DietRepository : RepositoryBase<DietEntity>, IDietRepository
    {
        public DietRepository(StayHealthyContext stayHealthyContext) : base(stayHealthyContext)
        {

        }

        public new async Task<IEnumerable<DietEntity>> GetAllAsync()
        {
            return await StayHealthyContext.Diets
                .Where(x => !x.IsDeleted)
                .Include(x => x.CreatedBy)
                .Include(x => x.DietCategory)
                .ToListAsync();
        }

        public async Task<IEnumerable<DietEntity>> GetAllUserDietAsync(int userId)
        {
            return await StayHealthyContext.Diets
                .Where(x => !x.IsDeleted && x.CreatedById == userId)
                .Include(x => x.CreatedBy)
                .Include(x => x.DietCategory)
                .ToListAsync();
        }

        public async Task<DietEntity> GetDietByIdAsync(int id)
        {
            return await StayHealthyContext.Diets
                .Include(x => x.CreatedBy)
                .Include(x => x.DietCategory)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
