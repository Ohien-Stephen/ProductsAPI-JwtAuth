using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Domain.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[,]
                {
                    { new Guid("fc815678-260b-4f16-8fc0-6e53854f3228"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m },
                    { new Guid("ad83ba06-b2d8-4837-b68c-51ff40a267f1"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m },
                    { new Guid("a14e6ba5-1752-4df9-890e-fffdb6f158c0"), "Phones & Tablets", "Latest tchno andriod phone", "Techo Hot 8 lite", 38000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("d2fcc8c8-c47c-42f4-878c-952ca33e44fb"), "admin@yahoo.com", "111111", "Admin", "admin" },
                    { new Guid("b0bea701-844b-432e-892b-c5cd575bb775"), "user@gmail.com", "222222", "User", "user" },
                    { new Guid("3a3571e0-be0d-4228-a214-c52bbbc2ae71"), "stephen@hotmail.com", "333333", "User", "stephen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ApplicationUserId",
                table: "RefreshTokens",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
