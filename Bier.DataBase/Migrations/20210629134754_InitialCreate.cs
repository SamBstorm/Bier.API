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
                    { 1, new DateTime(1987, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "samuel.legrain@bstorm.be", "Samuel", "Legrain", new byte[] { 76, 234, 79, 27, 156, 200, 45, 216, 30, 63, 135, 157, 52, 24, 18, 101, 205, 108, 225, 162, 198, 164, 111, 176, 127, 193, 143, 148, 154, 245, 114, 150 }, "6c4f9fee-0592-4d3e-83cb-f6a5eb9a54d0" },
                    { 2, new DateTime(1987, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.person@bstorm.be", "Michael", "Person", new byte[] { 132, 224, 187, 241, 6, 73, 11, 187, 216, 55, 22, 236, 43, 231, 36, 60, 139, 66, 229, 1, 218, 126, 92, 97, 86, 81, 150, 255, 26, 143, 24, 94 }, "3624bfea-16b3-4234-9d2d-1a167f3dc81c" },
                    { 3, new DateTime(1987, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "khun.lee@bstorm.be", "Khun", "Lee", new byte[] { 89, 149, 107, 81, 227, 173, 52, 192, 86, 39, 184, 39, 204, 64, 126, 46, 40, 119, 85, 154, 24, 34, 58, 163, 88, 228, 226, 170, 37, 65, 120, 26 }, "f9ea561a-7a1a-42c7-8fd7-8840e89531d8" }
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
