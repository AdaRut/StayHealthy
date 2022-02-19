using Microsoft.EntityFrameworkCore.Migrations;

namespace stayHealthy.DataAccess.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_DietCategories_DietCategoryId",
                table: "Diets");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_DietCategories_DietCategoryId",
                table: "Diets",
                column: "DietCategoryId",
                principalTable: "DietCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_DietCategories_DietCategoryId",
                table: "Diets");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_DietCategories_DietCategoryId",
                table: "Diets",
                column: "DietCategoryId",
                principalTable: "DietCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
