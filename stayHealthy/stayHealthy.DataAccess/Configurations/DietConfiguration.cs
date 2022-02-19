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
    public class DietConfiguration : IEntityTypeConfiguration<DietEntity>
    {
        public void Configure(EntityTypeBuilder<DietEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.MaxCalories)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.Property(x => x.ModificationDate)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.HasOne(x => x.CreatedBy)
               .WithMany(y => y.CreatedDiets)
               .HasForeignKey(x => x.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.ModifiedDiets)
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.DietCategory)
                .WithMany(y => y.Diets)
                .HasForeignKey(x => x.DietCategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
