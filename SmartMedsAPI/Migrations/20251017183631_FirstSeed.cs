using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartMedsAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "CreatedAt", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("badc6845-6d80-4b28-bff6-7d8ddd361fb6"), new DateTime(2025, 10, 17, 18, 30, 0, 0, DateTimeKind.Utc), "Aspirin", 30 },
                    { new Guid("fa8aad6a-d93a-4ed3-943c-684502e5ecbf"), new DateTime(2025, 10, 17, 18, 30, 0, 0, DateTimeKind.Utc), "Ibuprofen", 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medications");
        }
    }
}
