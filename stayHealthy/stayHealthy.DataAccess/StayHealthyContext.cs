using Microsoft.EntityFrameworkCore;
using stayHealthy.DataAccess.Configurations;
using stayHealthy.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess
{
    public class StayHealthyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DietEntity> Diets { get; set; }
        public DbSet<DietCategoryEntity> DietCategories { get; set; }
        public DbSet<MealEntity> Meals { get; set; }

        public StayHealthyContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<UserEntity>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<DietEntity>(new DietConfiguration());
            modelBuilder.ApplyConfiguration<DietCategoryEntity>(new DietCategoryConfiguration());
            modelBuilder.ApplyConfiguration<MealEntity>(new MealConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
