using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRecipe_Event_EventsEventId",
                table: "EventRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRecipe_Recipe_RecipesRecipeId",
                table: "EventRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Event_EventId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_EventId",
                table: "Guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRecipe",
                table: "EventRecipe");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Guest");

            migrationBuilder.RenameColumn(
                name: "RecipesRecipeId",
                table: "EventRecipe",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "EventsEventId",
                table: "EventRecipe",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRecipe_RecipesRecipeId",
                table: "EventRecipe",
                newName: "IX_EventRecipe_RecipeId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "recipe_image",
                table: "Recipe",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<int>(
                name: "event_recipe_id",
                table: "EventRecipe",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Event",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRecipe",
                table: "EventRecipe",
                column: "event_recipe_id");

            migrationBuilder.CreateTable(
                name: "EventGuest",
                columns: table => new
                {
                    event_guest_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    GuestId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuest", x => x.event_guest_id);
                    table.ForeignKey(
                        name: "FK_EventGuest_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuest_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guest",
                        principalColumn: "guest_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRecipe_EventId",
                table: "EventRecipe",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuest_EventId",
                table: "EventGuest",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuest_GuestId",
                table: "EventGuest",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRecipe_Event_EventId",
                table: "EventRecipe",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRecipe_Recipe_RecipeId",
                table: "EventRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRecipe_Event_EventId",
                table: "EventRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRecipe_Recipe_RecipeId",
                table: "EventRecipe");

            migrationBuilder.DropTable(
                name: "EventGuest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRecipe",
                table: "EventRecipe");

            migrationBuilder.DropIndex(
                name: "IX_EventRecipe_EventId",
                table: "EventRecipe");

            migrationBuilder.DropColumn(
                name: "event_recipe_id",
                table: "EventRecipe");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "EventRecipe",
                newName: "RecipesRecipeId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventRecipe",
                newName: "EventsEventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRecipe_RecipeId",
                table: "EventRecipe",
                newName: "IX_EventRecipe_RecipesRecipeId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "recipe_image",
                table: "Recipe",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Guest",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Event",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRecipe",
                table: "EventRecipe",
                columns: new[] { "EventsEventId", "RecipesRecipeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Guest_EventId",
                table: "Guest",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRecipe_Event_EventsEventId",
                table: "EventRecipe",
                column: "EventsEventId",
                principalTable: "Event",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRecipe_Recipe_RecipesRecipeId",
                table: "EventRecipe",
                column: "RecipesRecipeId",
                principalTable: "Recipe",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Event_EventId",
                table: "Guest",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "event_id");
        }
    }
}
