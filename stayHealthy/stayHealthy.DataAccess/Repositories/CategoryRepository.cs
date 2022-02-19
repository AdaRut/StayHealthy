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
    public class CategoryRepository : RepositoryBase<DietCategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(StayHealthyContext stayHealthyContext) : base(stayHealthyContext)
        {

        }
        public new async Task<IEnumerable<DietCategoryEntity>> GetAllAsync()
        {
            return await StayHealthyContext.DietCategories
                .Where(x => !x.IsDeleted)
                .Include(x => x.CreatedBy)
                .ToListAsync();
        }
    }

    
}
