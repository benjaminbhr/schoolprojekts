﻿// <auto-generated />
using CocktailsConsole;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CocktailsConsole.Migrations
{
    [DbContext(typeof(Cocktail))]
    partial class CocktailModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CocktailsConsole.AlcoholBrand", b =>
                {
                    b.Property<int>("AlcBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("AlcBrandId");

                    b.ToTable("AlcoholBrand");
                });

            modelBuilder.Entity("CocktailsConsole.IngredientBrand", b =>
                {
                    b.Property<int>("IngBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("IngBrandId");

                    b.ToTable("IngredientBrand");
                });
#pragma warning restore 612, 618
        }
    }
}
