﻿// <auto-generated />
using System;
using CocktailsConsole;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CocktailsConsole.Migrations
{
    [DbContext(typeof(CocktailContext))]
    partial class CocktailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CocktailsConsole.Alcohol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CocktailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.ToTable("Alcohol");
                });

            modelBuilder.Entity("CocktailsConsole.Cocktail", b =>
                {
                    b.Property<int>("CocktailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CocktailId");

                    b.ToTable("Cocktail");
                });

            modelBuilder.Entity("CocktailsConsole.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CocktailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("CocktailsConsole.Alcohol", b =>
                {
                    b.HasOne("CocktailsConsole.Cocktail", null)
                        .WithMany("AlcoholBrand")
                        .HasForeignKey("CocktailId");
                });

            modelBuilder.Entity("CocktailsConsole.Ingredient", b =>
                {
                    b.HasOne("CocktailsConsole.Cocktail", null)
                        .WithMany("IngredientBrand")
                        .HasForeignKey("CocktailId");
                });

            modelBuilder.Entity("CocktailsConsole.Cocktail", b =>
                {
                    b.Navigation("AlcoholBrand");

                    b.Navigation("IngredientBrand");
                });
#pragma warning restore 612, 618
        }
    }
}