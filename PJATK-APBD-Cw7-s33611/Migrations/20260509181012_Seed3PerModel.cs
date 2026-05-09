using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PJATK_APBD_Cw7_s33611.Migrations
{
    /// <inheritdoc />
    public partial class Seed3PerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[] { 3, "AMV", new DateTime(1999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amvidia" });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 3, "CPU", "Central Processing Unit" });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[] { 3, new DateTime(2011, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "YetAnotherPC3", 1, 10, 50f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
