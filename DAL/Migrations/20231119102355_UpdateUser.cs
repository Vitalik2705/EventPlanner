#nullable disable

namespace DAL.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 6,
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 19, 10, 23, 55, 402, DateTimeKind.Utc).AddTicks(1705), new DateTime(2023, 11, 19, 10, 23, 55, 402, DateTimeKind.Utc).AddTicks(1707) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 6,
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 14, 12, 36, 20, 475, DateTimeKind.Utc).AddTicks(6818), new DateTime(2023, 11, 14, 12, 36, 20, 475, DateTimeKind.Utc).AddTicks(6825) });
        }
    }
}
