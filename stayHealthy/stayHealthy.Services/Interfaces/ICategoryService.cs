using stayHealthy.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<DietCategory>> GetAllAsync();
    }
}
