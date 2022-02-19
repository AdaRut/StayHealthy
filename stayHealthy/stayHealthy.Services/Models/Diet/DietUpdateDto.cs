using stayHealthy.Services.Models.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Models.Diet
{
    public class DietUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCalories { get; set; }
        public int DietCategoryId { get; set; }
        public ICollection<MealUpdateDto> Meals { get; set; }
    }
}
