using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class assigningadminuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "04ac9c2b-5219-4a4f-9466-cd367d18cbf5", "f7f134cd-0c6c-46f8-80bf-dab0a7820b4c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04ac9c2b-5219-4a4f-9466-cd367d18cbf5", "f7f134cd-0c6c-46f8-80bf-dab0a7820b4c" });

        }
    }
}
