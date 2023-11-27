// <copyright file="20231027125141_Update-Database-And_added-images.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace DAL.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UpdateDatabaseAnd_addedimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "User",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "User",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "User",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "User",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Recipe",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "Recipe",
                newName: "calories");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Recipe",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Recipe",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CookingTime",
                table: "Recipe",
                newName: "cooking_time");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "IngredientUnit",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Ingredient",
                table: "IngredientUnit",
                newName: "ingredient");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Guest",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guest",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Guest",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Event",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Event",
                newName: "created_date");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<byte[]>(
                name: "user_image",
                table: "User",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "recipe_image",
                table: "Recipe",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Guest",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_image",
                table: "User");

            migrationBuilder.DropColumn(
                name: "recipe_image",
                table: "Recipe");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "User",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "User",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "User",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "User",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Recipe",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "calories",
                table: "Recipe",
                newName: "Calories");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Recipe",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Recipe",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "cooking_time",
                table: "Recipe",
                newName: "CookingTime");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "IngredientUnit",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "ingredient",
                table: "IngredientUnit",
                newName: "Ingredient");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Guest",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Guest",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Guest",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Event",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Event",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Event",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "User",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Guest",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
