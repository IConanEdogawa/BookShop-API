using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6621b33b-e572-4a1e-8022-abd647367dc7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a2fc8bb7-4bf0-44c5-838d-70e45aafc98d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f63a1353-5cd6-49b3-b7a7-b59eb61a6df0"));

            migrationBuilder.AddColumn<string>(
                name: "PdfUrl",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("46dab14f-304e-4279-85bb-e9423f2fd54d"), "PremiumUser" },
                    { new Guid("b222d3f9-07ac-42c2-8386-534be319d016"), "User" },
                    { new Guid("fc04a48e-8003-4f87-bdd6-217c523d5b3a"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46dab14f-304e-4279-85bb-e9423f2fd54d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b222d3f9-07ac-42c2-8386-534be319d016"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc04a48e-8003-4f87-bdd6-217c523d5b3a"));

            migrationBuilder.DropColumn(
                name: "PdfUrl",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6621b33b-e572-4a1e-8022-abd647367dc7"), "Admin" },
                    { new Guid("a2fc8bb7-4bf0-44c5-838d-70e45aafc98d"), "User" },
                    { new Guid("f63a1353-5cd6-49b3-b7a7-b59eb61a6df0"), "PremiumUser" }
                });
        }
    }
}
