using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Entities.Base
{
    public class ModifiableEntity : BaseEntity
    {
        public DateTime? ModificationDate { get; set; }
        public int? ModifiedById { get; set; }
        public virtual UserEntity ModifiedBy { get; set; }
    }
}
