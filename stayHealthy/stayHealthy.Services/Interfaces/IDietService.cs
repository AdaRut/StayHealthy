using stayHealthy.Services.Models.Diet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Interfaces
{
    public interface IDietService
    {
        Task<DietDetailDto> CreateDietAsync(DietCreateDto value, int userId);
        Task<IEnumerable<DietListItemDto>> GetAllDietsAsync();
        Task<IEnumerable<DietListItemDto>> GetAllUserDietsAsync(int userId);
        Task<DietDetailDto> GetDietByIdAsync(int id);
        Task<DietDetailDto> UpdateDietAsync(DietUpdateDto value, int userId);
        Task<DietDetailDto> DeleteDietAsync(int id, int userId);
    }
}
