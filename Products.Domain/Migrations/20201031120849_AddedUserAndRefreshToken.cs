using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Domain.Migrations
{
    public partial class AddedUserAndRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("28447562-dfb2-4160-8ade-e38ab566412a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb681caa-596e-446e-b9e5-6408e8678b60"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Expiry = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { new Guid("40fbdcdd-9af7-4faa-8986-398b75841a90"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { new Guid("ed63e18a-1f8c-42c5-bc45-1b67cfc2e0fd"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ApplicationUserId",
                table: "RefreshTokens",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40fbdcdd-9af7-4faa-8986-398b75841a90"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ed63e18a-1f8c-42c5-bc45-1b67cfc2e0fd"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { new Guid("fb681caa-596e-446e-b9e5-6408e8678b60"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { new Guid("28447562-dfb2-4160-8ade-e38ab566412a"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m });
        }
    }
}
