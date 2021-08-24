using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsConsole.Migrations
{
    public partial class addingThingsToContextlol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alcohols_Cocktail_CocktailId",
                table: "Alcohols");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Cocktail_CocktailId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_CocktailId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Alcohols_CocktailId",
                table: "Alcohols");

            migrationBuilder.DropColumn(
                name: "CocktailId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CocktailId",
                table: "Alcohols");

            migrationBuilder.CreateTable(
                name: "AlcoholAndAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlcoholBrandAlcBrandId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CocktailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholAndAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlcoholAndAmount_Alcohols_AlcoholBrandAlcBrandId",
                        column: x => x.AlcoholBrandAlcBrandId,
                        principalTable: "Alcohols",
                        principalColumn: "AlcBrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlcoholAndAmount_Cocktail_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktail",
                        principalColumn: "CocktailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientAndAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientBrandIngBrandId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CocktailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientAndAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientAndAmount_Cocktail_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktail",
                        principalColumn: "CocktailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientAndAmount_Ingredients_IngredientBrandIngBrandId",
                        column: x => x.IngredientBrandIngBrandId,
                        principalTable: "Ingredients",
                        principalColumn: "IngBrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholAndAmount_AlcoholBrandAlcBrandId",
                table: "AlcoholAndAmount",
                column: "AlcoholBrandAlcBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholAndAmount_CocktailId",
                table: "AlcoholAndAmount",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAndAmount_CocktailId",
                table: "IngredientAndAmount",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAndAmount_IngredientBrandIngBrandId",
                table: "IngredientAndAmount",
                column: "IngredientBrandIngBrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlcoholAndAmount");

            migrationBuilder.DropTable(
                name: "IngredientAndAmount");

            migrationBuilder.AddColumn<int>(
                name: "CocktailId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CocktailId",
                table: "Alcohols",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CocktailId",
                table: "Ingredients",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_Alcohols_CocktailId",
                table: "Alcohols",
                column: "CocktailId");

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
    }
}
