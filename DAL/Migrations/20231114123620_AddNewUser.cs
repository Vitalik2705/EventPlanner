#nullable disable

namespace DAL.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class AddNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "user_id", "created_date", "email", "gender", "modified_date", "name", "password", "phone_number", "surname", "user_image" },
                values: new object[] { 6, new DateTime(2023, 11, 14, 12, 36, 20, 475, DateTimeKind.Utc).AddTicks(6818), "1111", "Female", new DateTime(2023, 11, 14, 12, 36, 20, 475, DateTimeKind.Utc).AddTicks(6825), "Сальнікова", "1111", "8432652", "Божена", new byte[] { 0, 0, 0, 0, 0, 0 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 6);
        }
    }
}
