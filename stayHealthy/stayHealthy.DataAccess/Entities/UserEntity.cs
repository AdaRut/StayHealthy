using stayHealthy.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual IEnumerable<DietEntity> CreatedDiets { get; set; }
        public virtual IEnumerable<DietEntity> ModifiedDiets { get; set; }
        public virtual IEnumerable<MealEntity> CreatedMeals { get; set; }
        public virtual IEnumerable<MealEntity> ModifiedMeals { get; set; }
        public virtual IEnumerable<DietCategoryEntity> CreatedCategories { get; set; }
        public virtual IEnumerable<DietCategoryEntity> ModifiedCategories { get; set; }
    }
}
