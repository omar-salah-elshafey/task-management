using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class seedingRolesandaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04ac9c2b-5219-4a4f-9466-cd367d18cbf5", "1", "Admin", "ADMIN" },
                    { "1bdd9c6c-c4f0-4f4a-ae18-1ff69ab9b5a5", "2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7f134cd-0c6c-46f8-80bf-dab0a7820b4c", 0, "20733d92-928c-4bb3-be40-d56a69cf7647", new DateTime(2024, 10, 24, 18, 18, 3, 404, DateTimeKind.Utc).AddTicks(4742), "omarsalah@test.com", true, "Omar", false, "Salah", false, null, "OMARSALAH@TEST.COM", "OMAR_SALAH", "AQAAAAIAAYagAAAAELMkcmHyJJJEbzFhK2PDBhNzpzBFrVTJSLgTvtCrVeIukJ9mfhmw6EQ6PWMz8yT97g==", null, false, null, "f6ae4220-93d6-40dc-97ad-703d9125e9c9", false, "omar_salah" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04ac9c2b-5219-4a4f-9466-cd367d18cbf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bdd9c6c-c4f0-4f4a-ae18-1ff69ab9b5a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7f134cd-0c6c-46f8-80bf-dab0a7820b4c");
        }
    }
}
