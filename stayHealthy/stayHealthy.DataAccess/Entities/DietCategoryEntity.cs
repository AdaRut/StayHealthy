using stayHealthy.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Entities
{
    public class DietCategoryEntity : ModifiableEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<DietEntity> Diets { get; set; }

    }
}
