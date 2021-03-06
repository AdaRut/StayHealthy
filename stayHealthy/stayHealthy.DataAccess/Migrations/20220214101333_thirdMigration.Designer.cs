// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stayHealthy.DataAccess;

namespace stayHealthy.DataAccess.Migrations
{
    [DbContext(typeof(StayHealthyContext))]
    [Migration("20220214101333_thirdMigration")]
    partial class thirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.DietCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("DietCategories");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.DietEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DietCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCalories")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DietCategoryId");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.MealEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DietId");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.DietCategoryEntity", b =>
                {
                    b.HasOne("stayHealthy.DataAccess.Entities.UserEntity", "CreatedBy")
                        .WithMany("CreatedCategories")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("stayHealthy.DataAccess.Entities.UserEntity", "ModifiedBy")
                        .WithMany("ModifiedCategories")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.DietEntity", b =>
                {
                    b.HasOne("stayHealthy.DataAccess.Entities.UserEntity", "CreatedBy")
                        .WithMany("CreatedDiets")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("stayHealthy.DataAccess.Entities.DietCategoryEntity", "DietCategory")
                        .WithMany("Diets")
                        .HasForeignKey("DietCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("stayHealthy.DataAccess.Entities.UserEntity", "ModifiedBy")
                        .WithMany("ModifiedDiets")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("DietCategory");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.MealEntity", b =>
                {
                    b.HasOne("stayHealthy.DataAccess.Entities.UserEntity", "CreatedBy")
                        .WithMany("CreatedMeals")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("stayHealthy.DataAccess.Entities.DietEntity", "Diet")
                        .WithMany("Meals")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("stayHealthy.DataAccess.Entities.UserEntity", "ModifiedBy")
                        .WithMany("ModifiedMeals")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("Diet");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.DietCategoryEntity", b =>
                {
                    b.Navigation("Diets");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.DietEntity", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("stayHealthy.DataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("CreatedCategories");

                    b.Navigation("CreatedDiets");

                    b.Navigation("CreatedMeals");

                    b.Navigation("ModifiedCategories");

                    b.Navigation("ModifiedDiets");

                    b.Navigation("ModifiedMeals");
                });
#pragma warning restore 612, 618
        }
    }
}
