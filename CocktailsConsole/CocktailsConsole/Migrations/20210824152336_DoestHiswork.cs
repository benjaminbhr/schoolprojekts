using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsConsole.Migrations
{
    public partial class DoestHiswork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alcohols",
                columns: table => new
                {
                    AlcBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcohols", x => x.AlcBrandId);
                });

            migrationBuilder.CreateTable(
                name: "Cocktail",
                columns: table => new
                {
                    CocktailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktail", x => x.CocktailId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngBrandId);
                });

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

            migrationBuilder.DropTable(
                name: "Alcohols");

            migrationBuilder.DropTable(
                name: "Cocktail");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
