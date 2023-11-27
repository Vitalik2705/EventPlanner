#nullable disable

namespace DAL.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

    /// <inheritdoc />
    public partial class CreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientUnit",
                columns: table => new
                {
                    ingredient_unit_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ingredient = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUnit", x => x.ingredient_unit_id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    CookingTime = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.recipe_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientUnitRecipe",
                columns: table => new
                {
                    IngredientsUnitsIngredientUnitId = table.Column<int>(type: "integer", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUnitRecipe", x => new { x.IngredientsUnitsIngredientUnitId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_IngredientUnitRecipe_IngredientUnit_IngredientsUnitsIngredi~",
                        column: x => x.IngredientsUnitsIngredientUnitId,
                        principalTable: "IngredientUnit",
                        principalColumn: "ingredient_unit_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientUnitRecipe_Recipe_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipe",
                        principalColumn: "recipe_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_Event_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRecipe",
                columns: table => new
                {
                    EventsEventId = table.Column<int>(type: "integer", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRecipe", x => new { x.EventsEventId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_EventRecipe_Event_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Event",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRecipe_Recipe_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipe",
                        principalColumn: "recipe_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    guest_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.guest_id);
                    table.ForeignKey(
                        name: "FK_Guest_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "event_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserId",
                table: "Event",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRecipe_RecipesRecipeId",
                table: "EventRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_EventId",
                table: "Guest",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUnitRecipe_RecipesRecipeId",
                table: "IngredientUnitRecipe",
                column: "RecipesRecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRecipe");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "IngredientUnitRecipe");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "IngredientUnit");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
