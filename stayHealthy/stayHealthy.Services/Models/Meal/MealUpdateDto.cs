using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Models.Meal
{
    public class MealUpdateDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
    }
}
