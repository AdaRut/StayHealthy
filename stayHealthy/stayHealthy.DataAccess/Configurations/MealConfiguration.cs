using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stayHealthy.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<MealEntity>
    {
        public void Configure(EntityTypeBuilder<MealEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Calories)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.Property(x => x.ModificationDate)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.HasOne(x => x.CreatedBy)
               .WithMany(y => y.CreatedMeals)
               .HasForeignKey(x => x.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.ModifiedMeals)
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Diet)
                .WithMany(y => y.Meals)
                .HasForeignKey(x => x.DietId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
