using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsConsole.Migrations
{
    public partial class remakingstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholAndAmount_Alcohols_AlcoholBrandAlcBrandId",
                table: "AlcoholAndAmount");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAndAmount_Ingredients_IngredientBrandIngBrandId",
                table: "IngredientAndAmount");

            migrationBuilder.DropIndex(
                name: "IX_IngredientAndAmount_IngredientBrandIngBrandId",
                table: "IngredientAndAmount");

            migrationBuilder.DropIndex(
                name: "IX_AlcoholAndAmount_AlcoholBrandAlcBrandId",
                table: "AlcoholAndAmount");

            migrationBuilder.DropColumn(
                name: "IngredientBrandIngBrandId",
                table: "IngredientAndAmount");

            migrationBuilder.DropColumn(
                name: "AlcoholBrandAlcBrandId",
                table: "AlcoholAndAmount");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "IngredientAndAmount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AlcoholAndAmount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "IngredientAndAmount");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AlcoholAndAmount");

            migrationBuilder.AddColumn<int>(
                name: "IngredientBrandIngBrandId",
                table: "IngredientAndAmount",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlcoholBrandAlcBrandId",
                table: "AlcoholAndAmount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAndAmount_IngredientBrandIngBrandId",
                table: "IngredientAndAmount",
                column: "IngredientBrandIngBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholAndAmount_AlcoholBrandAlcBrandId",
                table: "AlcoholAndAmount",
                column: "AlcoholBrandAlcBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholAndAmount_Alcohols_AlcoholBrandAlcBrandId",
                table: "AlcoholAndAmount",
                column: "AlcoholBrandAlcBrandId",
                principalTable: "Alcohols",
                principalColumn: "AlcBrandId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAndAmount_Ingredients_IngredientBrandIngBrandId",
                table: "IngredientAndAmount",
                column: "IngredientBrandIngBrandId",
                principalTable: "Ingredients",
                principalColumn: "IngBrandId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
