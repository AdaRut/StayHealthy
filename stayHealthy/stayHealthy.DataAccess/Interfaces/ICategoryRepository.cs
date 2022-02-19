using stayHealthy.DataAccess.Entities;
using stayHealthy.DataAccess.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<DietCategoryEntity>
    {
        new Task<IEnumerable<DietCategoryEntity>> GetAllAsync();
    }
}
