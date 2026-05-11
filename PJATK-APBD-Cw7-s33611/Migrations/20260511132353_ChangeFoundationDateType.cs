using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PJATK_APBD_Cw7_s33611.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFoundationDateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCComponents_PCs_PCId",
                table: "PCComponents");

            migrationBuilder.RenameColumn(
                name: "PCId",
                table: "PCComponents",
                newName: "PcId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FoundationDate",
                table: "ComponentManufacturers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoundationDate",
                value: new DateOnly(2015, 1, 5));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FoundationDate",
                value: new DateOnly(2001, 11, 9));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "FoundationDate",
                value: new DateOnly(1999, 12, 31));

            migrationBuilder.AddForeignKey(
                name: "FK_PCComponents_PCs_PcId",
                table: "PCComponents",
                column: "PcId",
                principalTable: "PCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCComponents_PCs_PcId",
                table: "PCComponents");

            migrationBuilder.RenameColumn(
                name: "PcId",
                table: "PCComponents",
                newName: "PCId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FoundationDate",
                table: "ComponentManufacturers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoundationDate",
                value: new DateTime(2015, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FoundationDate",
                value: new DateTime(2001, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "FoundationDate",
                value: new DateTime(1999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_PCComponents_PCs_PCId",
                table: "PCComponents",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
