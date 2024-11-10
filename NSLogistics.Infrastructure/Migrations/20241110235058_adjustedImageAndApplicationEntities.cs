using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSLogistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adjustedImageAndApplicationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("90241396-04ad-4e49-b917-a2f516a295e6"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "images",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ShipmentName",
                table: "applications",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                table: "applications",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ContainerNumber",
                table: "applications",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalDate",
                table: "applications",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("c2a378b7-aedf-4712-8a16-f616a413d5f3"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "images");

            migrationBuilder.AlterColumn<string>(
                name: "ShipmentName",
                table: "applications",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                table: "applications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContainerNumber",
                table: "applications",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalDate",
                table: "applications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedById", "DateOfBirth", "Email", "Firstname", "IdNumber", "IsActive", "IsDeleted", "Lastname", "Password", "Role", "Salt" },
                values: new object[] { new Guid("90241396-04ad-4e49-b917-a2f516a295e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vaja.Kacia@example.com", "Saba", "00000000001", true, false, "Sani-Peradze", "C62D1C801386EDBDB84735BA14E873B007AF19841A5EC0BE22AD34478FD33086", 0, "qzlxcBpNh8pJq5GP1V7OBA==" });
        }
    }
}
