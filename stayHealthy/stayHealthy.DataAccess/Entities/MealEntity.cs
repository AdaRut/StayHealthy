using stayHealthy.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Entities
{    
    public class MealEntity : ModifiableEntity
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int DietId { get; set; }
        public virtual DietEntity Diet { get; set; }
    }
}
