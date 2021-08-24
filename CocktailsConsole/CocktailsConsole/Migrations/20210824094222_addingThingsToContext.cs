using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsConsole.Migrations
{
    public partial class addingThingsToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholBrand_Cocktail_CocktailId",
                table: "AlcoholBrand");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientBrand_Cocktail_CocktailId",
                table: "IngredientBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientBrand",
                table: "IngredientBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlcoholBrand",
                table: "AlcoholBrand");

            migrationBuilder.RenameTable(
                name: "IngredientBrand",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "AlcoholBrand",
                newName: "Alcohols");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientBrand_CocktailId",
                table: "Ingredients",
                newName: "IX_Ingredients_CocktailId");

            migrationBuilder.RenameIndex(
                name: "IX_AlcoholBrand_CocktailId",
                table: "Alcohols",
                newName: "IX_Alcohols_CocktailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "IngBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alcohols",
                table: "Alcohols",
                column: "AlcBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alcohols_Cocktail_CocktailId",
                table: "Alcohols",
                column: "CocktailId",
                principalTable: "Cocktail",
                principalColumn: "CocktailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Cocktail_CocktailId",
                table: "Ingredients",
                column: "CocktailId",
                principalTable: "Cocktail",
                principalColumn: "CocktailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alcohols_Cocktail_CocktailId",
                table: "Alcohols");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Cocktail_CocktailId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alcohols",
                table: "Alcohols");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "IngredientBrand");

            migrationBuilder.RenameTable(
                name: "Alcohols",
                newName: "AlcoholBrand");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_CocktailId",
                table: "IngredientBrand",
                newName: "IX_IngredientBrand_CocktailId");

            migrationBuilder.RenameIndex(
                name: "IX_Alcohols_CocktailId",
                table: "AlcoholBrand",
                newName: "IX_AlcoholBrand_CocktailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientBrand",
                table: "IngredientBrand",
                column: "IngBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlcoholBrand",
                table: "AlcoholBrand",
                column: "AlcBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholBrand_Cocktail_CocktailId",
                table: "AlcoholBrand",
                column: "CocktailId",
                principalTable: "Cocktail",
                principalColumn: "CocktailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientBrand_Cocktail_CocktailId",
                table: "IngredientBrand",
                column: "CocktailId",
                principalTable: "Cocktail",
                principalColumn: "CocktailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
