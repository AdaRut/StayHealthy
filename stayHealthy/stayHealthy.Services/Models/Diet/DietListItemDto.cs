using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Models.Diet
{
    public class DietListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCalories { get; set; }
        public int DietCategoryId { get; set; }
        public string DietCategoryName { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByData { get; set; }
    }
}
