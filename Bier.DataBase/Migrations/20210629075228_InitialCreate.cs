using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bier.DataBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocietyName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<byte[]>(type: "VARBINARY(32)", nullable: false),
                    Salt = table.Column<string>(type: "CHAR(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AlcoholIntensity = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BrewerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_Brewers_BrewerId",
                        column: x => x.BrewerId,
                        principalTable: "Brewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brewers",
                columns: new[] { "Id", "Country", "SocietyName" },
                values: new object[,]
                {
                    { 1, "Belgium", "AB inbev" },
                    { 2, "Belgium", "Duvel Mortgat" },
                    { 3, "Nederland", "Heineken" },
                    { 4, "Danemark", "Carlsberg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "Password", "Salt" },
                values: new object[,]
                {
                    { 1, new DateTime(1987, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "samuel.legrain@bstorm.be", "Samuel", "Legrain", new byte[] { 75, 106, 45, 246, 69, 176, 192, 197, 114, 36, 113, 113, 247, 139, 231, 164, 21, 207, 133, 208, 153, 69, 81, 85, 230, 82, 1, 175, 136, 116, 224, 249 }, "1b69b7fc-7927-4ec8-8e95-9a81d28a06e4" },
                    { 2, new DateTime(1987, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.person@bstorm.be", "Michael", "Person", new byte[] { 176, 86, 149, 165, 120, 181, 95, 93, 132, 188, 75, 8, 124, 26, 142, 85, 153, 167, 251, 2, 91, 79, 41, 69, 231, 135, 103, 147, 110, 253, 63, 148 }, "8178b65a-b667-409a-92a9-1afbadccfcbe" },
                    { 3, new DateTime(1987, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "khun.lee@bstorm.be", "Khun", "Lee", new byte[] { 160, 232, 237, 18, 64, 207, 61, 54, 139, 219, 205, 224, 178, 17, 191, 114, 46, 188, 54, 71, 213, 164, 217, 184, 166, 228, 63, 50, 196, 162, 57, 196 }, "17709b40-6026-4250-9c87-e2dc2170d025" }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "AlcoholIntensity", "BrewerId", "Color", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 5.5m, 1, 0, "Jupiler", 1 },
                    { 2, 0m, 1, 0, "Jupiler 0", 1 },
                    { 3, 6.2m, 2, 0, "Duvel", 0 },
                    { 4, 8m, 2, 1, "Maredsous", 0 },
                    { 5, 4.5m, 3, 0, "Heineken", 1 },
                    { 6, 4.5m, 3, 2, "Heineken Special", 1 },
                    { 7, 5m, 4, 0, "Carlsberg", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_BrewerId",
                table: "Drinks",
                column: "BrewerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brewers");
        }
    }
}
