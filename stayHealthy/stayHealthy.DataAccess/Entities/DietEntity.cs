using stayHealthy.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Entities
{
    public class DietEntity : ModifiableEntity
    {
        public string Name { get; set; }
        public int MaxCalories { get; set; }
        public int DietCategoryId { get; set; }
        public virtual DietCategoryEntity DietCategory { get; set; }
        public virtual IEnumerable<MealEntity> Meals { get; set; }
    }
}
