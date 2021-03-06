using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stayHealthy.Services.Models.Meal;

namespace stayHealthy.Services.Models.Diet
{
    public class DietDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCalories { get; set; }
        public int DietCategoryId { get; set; }
        public string DietCategoryName { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByData { get; set; }
        public ICollection<MealDto> Meals { get; set; }
    }
}
